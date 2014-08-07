using UnityEngine;
using System.Collections;

public class EcosystemWeatherCloud : MonoBehaviour
{

	public float smooth = 100;
	private Vector3 newPosition;


	// Use this for initialization
	void Start ()
	{
		newPosition = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		PositionChanging();
	}


	void PositionChanging ()
	{
		Vector3 positionA = new Vector3(-10000, 3, 0);
		Vector3 positionB = new Vector3(10000, 3, 0);
		
		if(Input.GetKeyDown(KeyCode.Q))
			newPosition = positionA;
		if(Input.GetKeyDown(KeyCode.E))
			newPosition = positionB;
		
		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
	}
}

