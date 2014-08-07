using UnityEngine;
using System.Collections;

public class ChildClassA : ParentClass
{
	
	// Use this for initialization
	void Start ()
	{
		
		if (!initialized) {
			ControllerClass.childA.entityCount++;
			initialized = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnEnable()
	{
		
		if (ControllerClass.childA != null && initialized) {
			ControllerClass.childA.entityCount++;
		}
	}
	
	
	void OnDisable()
	{
		ControllerClass.childA.entityCount--;
	}
}

