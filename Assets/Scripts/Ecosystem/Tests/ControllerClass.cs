using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerClass : MonoBehaviour
{

	public static ChildClassAData childA;
	public static ChildClassBData childB;

	public static Dictionary<string, ParentClassData> ChildClasses = new Dictionary<string, ParentClassData>();

	public delegate void AddToDictionary <T> (T classIn);

		// Use this for initialization
		void Awake ()
		{

			childA = GetComponent<ChildClassAData> ();
			childB = GetComponent<ChildClassBData> ();

		//ChildClasses["ChildClassAData"] = GetComponent<>();




		}
	
		// Update is called once per frame
		void Update ()
		{
			//Debug.Log ("A: " + childA.entityCount);
			//Debug.Log ("B: " + childB.entityCount);
		//Debug.Log (ChildClasses ["ChildClassAData"].entityCount);
		}

	public void testFoo(AddToDictionary<int> addTo)
	{

	}

}

