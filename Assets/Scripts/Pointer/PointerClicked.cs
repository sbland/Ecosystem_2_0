using UnityEngine;
using System.Collections;


public class PointerClicked : MonoBehaviour {




	public static GameObject selectedObject;
	public Material selectedMaterial;

	public GameObject playerController;
	public GameObject playerCamera;
	public GameObject guiCamera;


	private static GameObject playerControllerStatic;
	private static GameObject playerCameraStatic;
	private static GameObject guiCameraStatic;
	
	private Material selectedDefaultMaterial;

	// Use this for initialization
	void Start () {
		playerControllerStatic = playerController;
		playerCameraStatic = playerCamera;
		guiCameraStatic = guiCamera;


		guiCamera.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		//Detect object under pointer when clicked---
		Vector3 fwd = transform.TransformDirection(Vector3.down);
		
		RaycastHit hit;
		
		if(Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast (transform.position, fwd, out hit, 10)) 
			{
				Debug.Log("Clicked on: " + hit.transform.name );

				if(hit.transform.GetComponent<Clickable>())
				{
					PointerSettings pointerSettings = GetComponent<PointerSettings>();
					if(!pointerSettings.useTouchOSC)
					{
						DisableMouseLook();

					}



					if(selectedObject != null)
					{
						//selectedObject.renderer.material = selectedDefaultMaterial;
					}


					selectedDefaultMaterial = hit.transform.renderer.material;

					selectedObject = hit.transform.gameObject;
					selectedDefaultMaterial = selectedObject.transform.renderer.material;
					selectedObject.renderer.material = selectedMaterial;

					Clickable clickable = hit.transform.GetComponent<Clickable>();

					clickable.Action();



				}
				else{
					if(selectedObject != null)
					{
						selectedObject.renderer.material = selectedDefaultMaterial;
					}

				}

			}
		}
	}

	
	public static void DisableMouseLook(){

	
		playerControllerStatic.GetComponent<MouseLook>().enabled = false;
		playerControllerStatic.GetComponent<CharacterMotor> ().enabled = false;
		playerCameraStatic.GetComponent<MouseLook>().enabled = false;
		guiCameraStatic.SetActive(true);
	}
	
	public static void EnableMouseLook(){
		playerControllerStatic.GetComponent<MouseLook>().enabled = true;
		playerControllerStatic.GetComponent<CharacterMotor> ().enabled = true;
		playerCameraStatic.GetComponent<MouseLook>().enabled = true;
		guiCameraStatic.SetActive(false);
	
	}

}

