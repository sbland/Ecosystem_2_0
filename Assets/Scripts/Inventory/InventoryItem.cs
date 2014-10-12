using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Clickable))]
public class InventoryItem : MonoBehaviour
{

	public bool isUseable = false;
		// Use this for initialization
	void Start ()
	{
		if (gameObject.GetComponent<Clickable> ()) {
			Clickable clickable = GetComponent<Clickable>();
			clickable.onPointerClicked += AddItemToInventory;
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void AddItemToInventory()
	{
		for (int i = 0; i < InventoryManager.inventorySize - 1; i++) {
			if(InventoryManager.inventoryArray [i] == null)
			{
				//transform.position = new Vector3 (5000, 5000 , -5000 + (1*i));
				transform.position = InventoryManager.inventoryCameraStatic.transform.position + InventoryManager.inventoryCameraStatic.transform.forward + new Vector3(0,0,i);
				InventoryManager.inventoryArray [i] = gameObject;
				break;
			}
		}

	}


}

