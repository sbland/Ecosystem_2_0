using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Clickable))]
public class Tool : MonoBehaviour
{
	public AbilitiesManager.Abilities toolAction;

	// Use this for initialization
	void Start ()
	{
		if (gameObject.GetComponent<Clickable> ()) {
			Clickable clickable = GetComponent<Clickable>();
			clickable.onPointerClicked += AddToAbilities;
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void AddToAbilities()
	{
		AbilitiesManager.canChopDownTree = true;
		gameObject.SetActive (false);
	}
}

