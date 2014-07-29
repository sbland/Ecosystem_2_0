using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EcosystemEntityTreeHandler : MonoBehaviour {

	public static int treeCount = 0;
	public int RO_treeCount = 0;
	public static int treeMatureCount = 0;
	public int RO_treeMatureCount = 0;

	public float spreadDistance = 10;

	public static Dictionary<string, GameObject> treeDictionary = new Dictionary<string, GameObject>();
	public static List<string> treeDictKeys = new List<string>(treeDictionary.Keys);

	public static Dictionary<string, GameObject> treeDictionaryMature = new Dictionary<string, GameObject>();
	public static List<string> treeDictMatureKeys = new List<string>(treeDictionaryMature.Keys);

	public static int assignId = 1;

	public Terrain terrain;
	public TreeInstance treeInstance = new TreeInstance();


	public Texture2D terrainTexture;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		RO_treeCount = treeCount;
		RO_treeMatureCount = treeMatureCount;

	}

	void OnEnable (){
		Ecosystem.updateEcosystem += TreeUpdate;

	}
	
	void OnDisable () {
		Ecosystem.updateEcosystem -= TreeUpdate;
	}

	void TreeUpdate(){		
		
		//Debug.Log ("Updating Trees");


		int indexA = treeMatureCount - 1;
		int indexB = Random.Range (0, indexA);

		treeDictKeys = new List<string>(treeDictionary.Keys);
		treeDictMatureKeys = new List<string>(treeDictionaryMature.Keys);

		if (treeMatureCount > 0) {
			string randomKey = treeDictMatureKeys [indexB];

		



		GameObject treeFocus = treeDictionaryMature [randomKey];

		if (treeFocus != null) {
			//Debug.Log ("Updating:" + treeFocus.name);
			EcosystemEntityTree treeFocusData = treeFocus.GetComponent<EcosystemEntityTree> ();

			
			//treeFocus.renderer.material.color = new Color (0, 1, 0);
			CreateTree (treeFocus);	
			
				}
		}
	}

	void CreateTree(GameObject treeF){

		GameObject newInstance;

		RaycastHit hit;

	
		int rayHeightAdjust = 10;

		Vector3 position = new Vector3 (Random.Range (-spreadDistance, spreadDistance), rayHeightAdjust, Random.Range (-spreadDistance, spreadDistance));	

				
		if (Physics.Raycast (treeF.transform.position + position, -treeF.transform.up, out hit, 100)) {
						
						
			position.y = -hit.distance + rayHeightAdjust;

			Vector4 colourPixel = terrainTexture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);

			if(hit.transform.tag == "Ground" && colourPixel.x > 0.01)
			{
				if (treeF != null) {
					assignId++;
					newInstance = MonoBehaviour.Instantiate (treeF, treeF.transform.position + position, treeF.transform.rotation) as GameObject;
					
					
				} else {
					Debug.Log("Tree is NULL");
				}
			}
		} else {
			//Debug.Log("NoHit");
		}
	

	
		/*Terrain method--
		treeInstance.prototypeIndex = 0;
		
		treeInstance.color = Color.white;
		
		treeInstance.heightScale = 1;
		
		treeInstance.widthScale = 1;
		
		treeInstance.position = new Vector3 (Random.value, 0, Random.value);

		treeInstance.lightmapColor = Color.white;

				
		terrain.AddTreeInstance (treeInstance);
		

		terrain.Flush ();
*/
		
		
		
	}



}
