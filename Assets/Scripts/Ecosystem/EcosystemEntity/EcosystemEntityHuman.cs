using UnityEngine;
using System.Collections;

public class EcosystemEntityHuman : EcosystemEntity
{
	//Called at during Ecosystem update
	public override void EntityUpdate()
	{
		
	}
	
	public override void SetHandler()
	{
		handler = Ecosystem.humanHandler;
	}
}

