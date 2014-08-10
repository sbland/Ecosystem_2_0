using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityPool// : MonoBehaviour
{
	public static EntityPool current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public List<GameObject> pooledObjects;

	void Awake()
	{
		current = this;
	}

	void Start()
	{
		/*pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			AddToPool(pooledObject);
				}*/

	}

	void Update()
	{

	}

	public void SetupPool()
	{


	}

	public void Spawn()
	{
		Debug.Log ("Spawn");
		Vector3 position = new Vector3 (Random.Range (-100, 100), 0, Random.Range (-100, 100));	//offset position of raycast origin
		foreach (GameObject obj in pooledObjects) {
			if(!obj.activeInHierarchy)
			{
				obj.transform.position = new Vector3 (Random.Range (-100, 100), 0, Random.Range (-100, 100));
				obj.SetActive(true);
				break;
			}

		}
	}

	public void Die(){
		foreach (GameObject obj in pooledObjects) {
			if(obj.activeInHierarchy)
			{
				obj.SetActive(false);
				break;
			}
			
		}
	}

	public void AddToPool(GameObject pooledObjectIn){
		GameObject obj = (GameObject)MonoBehaviour.Instantiate(pooledObjectIn);
		obj.SetActive(false);
		pooledObjects.Add(obj);
	}



	//list contains all entitys in pool 
}

