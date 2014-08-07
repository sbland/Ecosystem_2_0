using UnityEngine;
using System.Collections;

public class EcosystemWeather : MonoBehaviour
{
	private GameObject cloudSpawned;
	public GameObject cloudResource;

	// Use this for initialization
	void Start ()
	{
		spawnCloud ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void spawnCloud()
	{
		//cloudResource = (GameObject)Resources.Load("Cloud");
		cloudSpawned = MonoBehaviour.Instantiate (cloudResource, new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;
	}
}

