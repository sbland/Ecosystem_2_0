using UnityEngine;
using System.Collections;

public class MaterialChooser : MonoBehaviour {

	public Material[] materialOptions;


	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		Clickable clickable = transform.GetComponent<Clickable> ();
		clickable.onPointerClicked += StartMaterialChooser;
	}
	
	void OnDisable(){
		Clickable clickable = transform.GetComponent<Clickable> ();
		clickable.onPointerClicked -= StartMaterialChooser;
	}


	// Update is called once per frame
	void Update () {
	
	}

	void StartMaterialChooser(){


		Debug.Log ("Start Material Chooser");


	}

	public void ChangeMaterial(int id) {

	}

}
