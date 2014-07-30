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
		
		//Debug.Log ("Updating entitys");


		int indexA = entityMatureCount - 1;
		int indexB = Random.Range (0, indexA);


		//Refresh dictionary key lists
		entityDictKeys = new List<string>(entityDictionary.Keys);
		entityDictMatureKeys = new List<string>(entityDictionaryMature.Keys);


		if (entityMatureCount > 0) {
			string randomKey = entityDictMatureKeys [indexB];
			GameObject entityFocus = entityDictionaryMature [randomKey];

			if (entityFocus != null) {
				//Debug.Log ("Updating:" + entityFocus.name);
				EcosystemEntity entityFocusData = entityFocus.GetComponent<EcosystemEntity> ();

								//entityFocus.renderer.material.color = new Color (0, 1, 0);


				CreateEntity (entityFocus);	
				
				}

		}

	} //End entityUpdate



	void CreateEntity(GameObject entityF){

		GameObject newInstance;

		RaycastHit hit;

	
		int rayHeightAdjust = 10;

		Vector3 position = new Vector3 (Random.Range (-spreadDistance, spreadDistance), rayHeightAdjust, Random.Range (-spreadDistance, spreadDistance));	

				
		if (Physics.Raycast (entityF.transform.position + position, -entityF.transform.up, out hit, 100)) {
						
						
			position.y = -hit.distance + rayHeightAdjust;

			Vector4 colourPixel = terrainTexture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);

			if(hit.transform.tag == "Ground" && colourPixel.x > 0.01)
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



}
