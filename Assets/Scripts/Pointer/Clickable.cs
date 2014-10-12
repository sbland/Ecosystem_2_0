using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {


	[System.Serializable]
	public class StoreDefault{
		
		public Material defaultMaterial;

		
	}

	public StoreDefault storeDefault;


	public delegate void OnPointerClicked();
	public event OnPointerClicked onPointerClicked;




	public void Action () {
			if(onPointerClicked != null)
			onPointerClicked ();
	}

	void Start()
	{
		storeDefault.defaultMaterial = gameObject.renderer.material;
	}


}
