using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityPoolObjectTest : MonoBehaviour
{	
	public bool initialized = false;
	public int pooledAmount = 20;

	void Start()
	{
		if (!initialized) {
			OnEnableExtended ();
		}
	}




	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			EntityPool.current.Spawn();
		}
		if(Input.GetKeyDown(KeyCode.N))
		{
			EntityPool.current.Die();
		}
	}

	void OnEnableExtended()
	{
		initialized = true;
		EntityPool.current.pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			EntityPool.current.AddToPool(gameObject);
		}
	}
}

