using UnityEngine;
using System.Collections;

public class ControllerClass : MonoBehaviour
{

	public static ChildClassAData childA;
	public static ChildClassBData childB;

		// Use this for initialization
		void Awake ()
		{

			childA = GetComponent<ChildClassAData> ();
			childB = GetComponent<ChildClassBData> ();

		}
	
		// Update is called once per frame
		void Update ()
		{
			Debug.Log ("A: " + childA.entityCount);
			Debug.Log ("B: " + childB.entityCount);
		}


}

