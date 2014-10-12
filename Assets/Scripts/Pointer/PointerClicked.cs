using UnityEngine;
using System.Collections;


public class PointerClicked : MonoBehaviour {

	//Selections
	public static GameObject selectedObject;
	public static GameObject previousSelectedObject;

	//Display
	public Material highlightSelectedMaterial;

	//MouseControl
	public GameObject playerController;
	public GameObject playerCamera;
	public GameObject guiCamera;

	private static GameObject playerControllerStatic;
	private static GameObject playerCameraStatic;
	private static GameObject guiCameraStatic;

	PointerSettings pointerSettings;// = gameObject.GetComponent<PointerSettings>();


	// Use this for initialization
	void Start () {
		//set statics
		playerControllerStatic = playerController;
		playerCameraStatic = playerCamera;
		guiCameraStatic = guiCamera;

		pointerSettings = gameObject.GetComponent<PointerSettings>();

		if (guiCamera != null) 
		{
			guiCamera.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {

		//Detect object under pointer when clicked---
		Vector3 fwd = transform.TransformDirection(Vector3.down);
		
		RaycastHit hit;
		
		if(Input.GetMouseButtonDown(0) || pointerSettings.liveUpdate)
		{
			previousSelectedObject = selectedObject;
			if(previousSelectedObject != null)
			{
				ResetPreviousSelection();
			}


			if (Physics.Raycast (transform.position, fwd, out hit, 10)) 
			{
				selectedObject = hit.transform.gameObject;
				Debug.Log("Clicked on: " + hit.transform.name );
								
				if(selectedObject.GetComponent<Clickable>())
				{
					if(!pointerSettings.useTouchOSC)
					{
						DisableMouseLook();
					}

				
					selectedObject.renderer.material = highlightSelectedMaterial;
					Clickable clickable = selectedObject.GetComponent<Clickable>();
					clickable.Action();
				}


			}else{
				selectedObject = null;
			}
		}
	}


	public void ResetPreviousSelection() {
		if (previousSelectedObject.GetComponent<Clickable> ())
			{
				Clickable clickable = previousSelectedObject.GetComponent<Clickable> ();
				previousSelectedObject.renderer.material = clickable.storeDefault.defaultMaterial;
			}
		}
	
	public static void DisableMouseLook(){

	
		playerControllerStatic.GetComponent<MouseLook>().enabled = false;
		playerControllerStatic.GetComponent<CharacterMotor> ().enabled = false;
		playerCameraStatic.GetComponent<MouseLook>().enabled = false;
		if(guiCameraStatic)guiCameraStatic.SetActive(true);
	}
	
	public static void EnableMouseLook(){
		playerControllerStatic.GetComponent<MouseLook>().enabled = true;
		playerControllerStatic.GetComponent<CharacterMotor> ().enabled = true;
		playerCameraStatic.GetComponent<MouseLook>().enabled = true;
		if(guiCameraStatic)guiCameraStatic.SetActive(false);
	
	}

}

