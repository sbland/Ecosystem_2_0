using UnityEngine;
using System.Collections;


[System.Serializable]
public class InventoryControls{
	public KeyCode openInventoryButton = KeyCode.I;
	public KeyCode[] slots = new KeyCode[6];
}

public class InventoryManager : MonoBehaviour
{
	public static GameObject[] inventoryArray;
	public Camera inventoryCamera;
	public static Camera inventoryCameraStatic;
	public Camera mainCamera;
	public static int inventorySize = 6;

	public InventoryControls controls;


	// Use this for initialization
	void Start ()
	{
		inventoryCameraStatic = inventoryCamera;
		inventoryArray = new GameObject[inventorySize];


		if (inventoryCamera != null) 
		{
			inventoryCamera.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown(controls.openInventoryButton))
		{
			if (inventoryCamera != null && !inventoryCamera.gameObject.activeSelf)
			{
				inventoryCamera.gameObject.SetActive (true) ;
			}else{ 
				inventoryCamera.gameObject.SetActive (false);
			}
			
		}


		if(Input.GetKeyDown(controls.slots[0]))
		{
			if(inventoryArray[0] != null)
			{
				inventoryArray[0].transform.position = mainCamera.transform.position + mainCamera.transform.forward * 2;
				inventoryArray[0] = null;

			}
		}
		if(Input.GetKeyDown(controls.slots[1]))
		{
			if(inventoryArray[1] != null)
			{
				inventoryArray[1].transform.position = mainCamera.transform.position + mainCamera.transform.forward * 2;
				inventoryArray[1] = null;
				
			}
		}

	}
}

