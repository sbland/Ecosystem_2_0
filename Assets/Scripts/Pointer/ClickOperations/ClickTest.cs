using UnityEngine;
using System.Collections;

public class ClickTest : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
			if (gameObject.GetComponent<Clickable> ()) {
			Clickable clickable = GetComponent<Clickable>();
			clickable.onPointerClicked += ClickTestHit;
				

				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
	public void ClickTestHit()
	{
		//gameObject.renderer.material.color = Color.blue;
	}

}

