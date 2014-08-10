using UnityEngine;
using System.Collections;

public class ChildClassBData : ParentClassData
{
	public int entityCount = 0;
	public EntityPool pool;
	// Use this for initialization
	
	public ChildClassBData childClassBData;
	void Awake ()
	{
		pool = new EntityPool ();
		//ControllerClass.AddToDictionary<ChildClassAData> addto;
		//ControllerClass.ChildClasses.Add("ChildClassBData", childClassBData);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			pool.Spawn();
		}
		if(Input.GetKeyDown(KeyCode.N))
		{
			pool.Die();
		}
	}
}

