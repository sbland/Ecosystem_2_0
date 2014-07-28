using UnityEngine;
using System.Collections;

public class Populate_Settings : MonoBehaviour {

	public int updateRate = 500;
	public int updateIntervals = 100;
	public int updateCount = 0;

	public delegate void UpdatePopulate ();
	public static event UpdatePopulate updatePopulate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate () {
		
		//EntityCounts();
		if (updateCount == updateRate) 
		{
			Debug.Log ("Updating All");
			if (updatePopulate != null){

				updatePopulate();
			}
			updateCount = 0;
		}
		updateCount++;
		
	}
}
