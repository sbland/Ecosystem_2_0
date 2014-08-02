using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EcosystemEntityHandler : MonoBehaviour {

	public static int entityCount = 0;
	public int RO_entityCount = 0;
	public static int entityMatureCount = 0;
	public int RO_entityMatureCount = 0;

	public float spreadDistance = 10;

	public static Dictionary<string, GameObject> entityDictionary = new Dictionary<string, GameObject>();
	public static List<string> entityDictKeys = new List<string>(entityDictionary.Keys);

	public static Dictionary<string, GameObject> entityDictionaryMature = new Dictionary<string, GameObject>();
	public static List<string> entityDictMatureKeys = new List<string>(entityDictionaryMature.Keys);

	public static int assignId = 1;

	public Terrain terrain;

	public Texture2D terrainTexture;

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

			if(CheckCreateValidity (entityFocus))
			   {
				CreateEntity (entityFocus);	
			}



		}

	} //End entityUpdate



	void CreateEntity(GameObject entityF){

		GameObject newInstance; 
		RaycastHit hit;

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
						
			if(!affectedBySeasons){
				return true;
			}else if(affectedBySeasons && entityFocusData.seedSeason == EcosystemTimeManager.season)
			{
				return true;
			}

		}
		return false;
	}



}
