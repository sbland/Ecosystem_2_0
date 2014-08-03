﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;



public class EcosystemEntityHandler : MonoBehaviour {

	public int entityCount = 0;
	public int RO_entityCount = 0;
	public int entityMatureCount = 0;
	public int RO_entityMatureCount = 0;

	public float spreadDistance = 10;

	public Dictionary<string, GameObject> entityDictionary = new Dictionary<string, GameObject>();
	public List<string> entityDictKeys;// = new List<string>(entityDictionary.Keys);

	public Dictionary<string, GameObject> entityDictionaryMature = new Dictionary<string, GameObject>();
	public List<string> entityDictMatureKeys;// = new List<string>(entityDictionaryMature.Keys);

	public int assignId = 1;

	public Terrain terrain;

	public Texture2D terrainTexture;
	public Texture2D textureDataTest;

	public bool affectedBySeasons = true;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		RO_entityCount = entityCount;
		RO_entityMatureCount = entityMatureCount;

	}

	void OnEnable (){
		Ecosystem.updateEcosystem += entityUpdate;

	}//end OnEnable
	
	void OnDisable () {
		Ecosystem.updateEcosystem -= entityUpdate;
	} //end OnDisable

	void entityUpdate(){		
		//Called during the ecosystemUpdate pass

		int indexTotal = entityMatureCount - 1;	//convert entity count to an array index
		int indexTarget = Random.Range (0, indexTotal); //find an index value between 0 and the total entity count index


		//Refresh dictionary key lists
		refreshDictKeys ();


		if (entityMatureCount > 0) {
			string randomKey = entityDictMatureKeys [indexTarget];
			GameObject entityFocus = entityDictionaryMature [randomKey];
			entityFocus.renderer.material.color = Color.red;


			if(CheckCreateValidity (entityFocus))
			{
				EcosystemEntity entityFocusData = entityFocus.GetComponent<EcosystemEntity> ();
				CreateEntity (entityFocus);	
				entityFocusData.childData.currentChildrenPerYear++;
			}



		}

	} //End entityUpdate



	void CreateEntity(GameObject entityF){

		GameObject newInstance; 
		RaycastHit hit;

		EcosystemEntity entityFEco = entityF.GetComponent<EcosystemEntity> ();

		int rayHeightAdjust = 10; //Height above original entity to cast ray from

		Vector3 position = new Vector3 (Random.Range (-spreadDistance, spreadDistance), rayHeightAdjust, Random.Range (-spreadDistance, spreadDistance));	//offset position of raycast origin

				
		if (Physics.Raycast (entityF.transform.position + position, -entityF.transform.up, out hit, 100)) {
						
						
			position.y = -hit.distance + rayHeightAdjust; //positions the entity on the ground



			Vector4 colourPixel = terrainTexture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y); //get colour info of splat map correesponding to the locatiuon of the raycast hit on the terrain

			if(hit.transform.tag == "Ground" && colourPixel.x > 0.01) //checks against the splatmap that it is a valid location
			{
				if (entityF != null) {
					assignId++;
					newInstance = MonoBehaviour.Instantiate (entityF, entityF.transform.position + position, entityF.transform.rotation) as GameObject;

					Ecosystem.atmosphere.OxygenCalc += entityFEco.atmosphereData.oxygenOut;

					//RecordToPNG(hit.textureCoord.x, hit.textureCoord.y);
					
				} else {
					Debug.Log("entity is NULL");
				}
			}
		} else {
			//Debug.Log("NoHit");
		}
	
				
		
	}

	void refreshDictKeys()
	{
		entityDictKeys = new List<string>(entityDictionary.Keys);
		entityDictMatureKeys = new List<string>(entityDictionaryMature.Keys);
	}

	bool CheckCreateValidity (GameObject entity)
	{
		
		if (entity != null) {

			EcosystemEntity entityFocusData = entity.GetComponent<EcosystemEntity> ();

			if(entityFocusData.childData.currentChildrenPerYear >= entityFocusData.childData.maxChildrenPerYear)
			{
				return false;
			}
			if(!affectedBySeasons){
				return true;
			}else if(affectedBySeasons && entityFocusData.seedSeason == EcosystemTimeManager.season)
			{
				return true;
			}

		}
		return false;
	}

	void RecordToPNG(float x, float y)
	{
		Vector4 changeColour = new Vector4 (255, 255, 0, 1);
		float pixelX = textureDataTest.width * x;
		float pixelY = textureDataTest.height *  y;
		textureDataTest.SetPixel((int)pixelX, (int)pixelY, Color.red);
		
		//textureDataTest.Apply();
		
		byte[] bytes = textureDataTest.EncodeToPNG ();
		File.WriteAllBytes (System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Ecosystem/" + "TestImage" + ".png", bytes);
	}


}
