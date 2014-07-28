using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

	public delegate void OnPointerClicked();
	public event OnPointerClicked onPointerClicked;


	public void Action () {
			if(onPointerClicked != null)
			onPointerClicked ();
	}


}
