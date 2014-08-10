using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChildClassA : ParentClass
{

	public int pooledAmount = 20;
	
	// Use this for initialization
	void Start ()
	{
		
		if (!initialized) {
			ControllerClass.childA.entityCount++;
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
		ControllerClass.childA.pool.pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			ControllerClass.childA.pool.AddToPool(gameObject);
		}
	}
}

