using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityPoolTest : MonoBehaviour
{
	public GameObject pooledObject;
	public int pooledAmount = 20;
	List<GameObject> pooledObjects;
	
	void Start()
	{
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			AddToPool();
		}
		//Invoke ("Spawn", 2f);
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			Spawn();
		}
		if(Input.GetKeyDown(KeyCode.N)){
			Die();
		}
	}
	
	void Spawn()
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
	
	void Die(){
		foreach (GameObject obj in pooledObjects) {
			if(obj.activeInHierarchy)
			{
				obj.SetActive(false);
				break;
			}
			
		}
	}
	
	void AddToPool(){
		GameObject obj = (GameObject)Instantiate(pooledObject);
		obj.SetActive(false);
		pooledObjects.Add(obj);
	}
	
	
	
	//list contains all entitys in pool 
}

