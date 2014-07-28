using UnityEngine;
using System.Collections;

public class MaterialChooserGUI : MonoBehaviour {

	float btn01 = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*
		 if(Input.GetKeyDown("Fire"){
			RaycastHit hit;
			Ray ray = menuCamera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100)){

			}
		}*/


	}

	void OnGUI(){


		//Material Chooser UI
		if (GUI.Button (new Rect (10, 5, 100, 30), "MaterialOption")) {

			if(PointerClicked.selectedObject != null)
			{
				if(PointerClicked.selectedObject.GetComponent<MaterialChooser>()){

					MaterialChooser materialChooser = PointerClicked.selectedObject.GetComponent<MaterialChooser>();
					PointerClicked.selectedObject.renderer.material = materialChooser.materialOptions[0];
					Debug.Log("Changing Material " + PointerClicked.selectedObject.name);		

					Finished();
					}
			}

		}


		if (GUI.Button (new Rect (10, 300, 100, 30), "Cancel")) {
			Finished();

			
		}


	}

	void Finished(){
		PointerClicked.EnableMouseLook();
		//camera.enabled = false;
		//enabled = false;
	}

}
