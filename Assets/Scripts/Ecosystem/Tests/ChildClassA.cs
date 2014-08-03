using UnityEngine;
using System.Collections;

public class ChildClassA : ParentClass
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnEnable()
	{
		if (ControllerClass.childA != null) {
							ControllerClass.childA.entityCount++;
					}
		}

	void OnDisable()
	{
		ControllerClass.childA.entityCount--;
	}
}

