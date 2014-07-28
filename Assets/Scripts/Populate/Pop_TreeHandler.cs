using UnityEngine;
using System.Collections;


public class Pop_TreeHandler : MonoBehaviour {


	public static int treeCount = 0;
	public static GameObject[] treeArray = new GameObject[100];

	public static bool requirementsMet = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnEnable (){
		Populate_Settings.updatePopulate += TreeUpdate;
	}
	
	void OnDisable () {
		Populate_Settings.updatePopulate -= TreeUpdate;
	}
	
	void TreeUpdate(){


		Debug.Log ("Updating Trees");

		if (requirementsMet) {
			CreateTree ();		
		}



	}

	void CreateTree(){

		GameObject newInstance;
		Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	

		//Debug.Log (treeArray[0].name);
		int index = treeCount - 1;
		int indexB = Random.Range (0, index);

		if (treeArray [index] != null) {
			newInstance = MonoBehaviour.Instantiate (treeArray [indexB], treeArray [indexB].transform.position + position, treeArray [indexB].transform.rotation) as GameObject;
			newInstance.name = "Tree_" + index;

				} else {
			Debug.Log("Tree Count NULL");
				}



	}

	void DestroyTree(){


	}

}
