using UnityEngine;
using System.Collections;

public class PointerGUI : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	void OnGUI ()
	{
		if(PointerClicked.selectedObject != null) GUI.TextArea (new Rect (500, 20, 200, 20), "Selected: " + PointerClicked.selectedObject.name);
	}
}

