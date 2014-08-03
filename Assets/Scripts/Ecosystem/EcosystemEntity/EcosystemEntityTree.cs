using UnityEngine;
using System.Collections;

public class EcosystemEntityTree : EcosystemEntity
{

	//Called at during Ecosystem update
	public override void EntityUpdate()
	{

	}

	public override void SetHandler()
	{
		handler = Ecosystem.treeHandler;
	}

}

