using UnityEngine;
using System.Collections;



public class Pop_Tree : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable () {

		Pop_TreeHandler.treeArray [Pop_TreeHandler.treeCount] = transform.gameObject;
		Pop_TreeHandler.treeCount ++;



	}

	void OnDisable () {
		Pop_TreeHandler.treeArray [Pop_TreeHandler.treeCount] = null;
		Pop_TreeHandler.treeCount --;
		}
}
