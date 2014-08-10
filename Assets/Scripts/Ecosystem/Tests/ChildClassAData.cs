using UnityEngine;
using System.Collections;

public class ChildClassAData : ParentClassData
{

	public int entityCount = 0;
	public EntityPool pool;
		// Use this for initialization

	public ChildClassAData childClassAData;
	void Awake ()
	{
		pool = new EntityPool ();
		//ControllerClass.AddToDictionary<ChildClassAData> addto;
		//ControllerClass.ChildClasses.Add("ChildClassAData", childClassAData);
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

