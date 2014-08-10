using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChildClassB : ParentClass
{

	
	public int pooledAmount = 20;
	
	// Use this for initialization
	void Start ()
	{
		
		if (!initialized) {
			ControllerClass.childB.entityCount++;
			OnEnableExtended();
			//initialized = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnEnable()
	{
		
		//		if (ControllerClass.childA != null && initialized) {
		//			ControllerClass.childA.entityCount++;
		//		}
	}
	
	
	void OnDisable()
	{
		//ControllerClass.childA.entityCount--;
	}
	
	void OnEnableExtended()
	{
		initialized = true;
		ControllerClass.childB.pool.pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			ControllerClass.childB.pool.AddToPool(gameObject);
		}
	}

}
	
