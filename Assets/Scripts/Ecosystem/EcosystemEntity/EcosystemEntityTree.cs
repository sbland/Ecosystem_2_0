using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Clickable))]
public class EcosystemEntityTree : EcosystemEntity
{

	public override void ChildStart()
	{
		if (gameObject.GetComponent<Clickable> ()) {
			Clickable clickable = GetComponent<Clickable>();
			clickable.onPointerClicked += ChopDownTree;
		}
	}

	//Called at during Ecosystem update
	public override void EntityUpdate()
	{

	}

	public override void SetHandler()
	{
		handler = Ecosystem.treeHandler;
	}

	public override void ChildUpdate()
	{


	}

	public void ChopDownTree()
	{
		if (AbilitiesManager.canChopDownTree) {
						Destroy (gameObject);
				} else {

				}

	}

}

