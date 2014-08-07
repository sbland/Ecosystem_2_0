using UnityEngine;
using System.Collections;

public class ChildClassAData : ParentClassData
{

	public int entityCount = 0;
		// Use this for initialization

	public ChildClassAData childClassAData;
		void Awake ()
		{
		ControllerClass.AddToDictionary<ChildClassAData> addto;
		ControllerClass.ChildClasses.Add("ChildClassAData", childClassAData);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}

