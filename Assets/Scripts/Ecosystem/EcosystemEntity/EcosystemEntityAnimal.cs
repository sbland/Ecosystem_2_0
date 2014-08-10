/*************************************************************************
  Ecosystem Entity Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:02/03/14
  Description: Parent entity class

 ------------------------------------------------------------------------
  History:

 ------------------------------------------------------------------------
 Contents
	1.	Imports
	2.	Variables
		2.1.
	3.	Standard Functions
		3.1. 	
	4.	Unique Functions
		4.1.	
	5.	Debug functions
		5.1.	
		
 *************************************************************************/


using UnityEngine;
using System.Collections;

public class EcosystemEntityAnimal : EcosystemEntity
{
	//Called at during Ecosystem update
	public override void EntityUpdate()
	{
		
	}
	
	public override void SetHandler()
	{
		handler = Ecosystem.animalHandler;
	}

	public override void ChildStart()
	{

	}
}

