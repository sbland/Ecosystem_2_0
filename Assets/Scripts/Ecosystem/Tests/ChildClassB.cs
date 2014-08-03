using UnityEngine;
using System.Collections;

public class ChildClassB : ParentClass
{

	
		// Use this for initialization
		void Start ()
		{

		if (!initialized) {
				ControllerClass.childB.entityCount++;
			initialized = true;
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

	void OnEnable()
	{

		if (ControllerClass.childB != null && initialized) {
			ControllerClass.childB.entityCount++;
		}
	}


	void OnDisable()
	{
		ControllerClass.childB.entityCount--;
	}

}
	
