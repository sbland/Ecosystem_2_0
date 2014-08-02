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

public class EcosystemEntity : MonoBehaviour
{
	public int age = 0; // in Seconds

	public enum AgeStatus {DEFAULT,YOUNG, MATURE, OLD, DEAD};
	public AgeStatus ageStatus = AgeStatus.YOUNG;

	public int matureAge = 5; //age that reproduction is allowed
	public int oldAge = 7; // age that reproduction is stopped
	public int predictedDeath = 10;// int Seconds age that death is predicted

	
	public float growthRate = 1f;
	public Vector3 growthAmount = new Vector3 (); // vector to add to current size on growth
	public Vector3 initialScale = new Vector3(1,1,1);


	public string uniqueName = "";
	
	public bool seedEnabled = true;

	public EcosystemTimeManager.Season seedSeason = EcosystemTimeManager.Season.SPRING;



	protected void Aging ()
	{
		age +=1;
		
	}

	protected IEnumerator Growing()
	{
		//gameObject.renderer.material.color = new Color(ageRatio, 0,0);
		while (ageStatus != AgeStatus.OLD) {
			gameObject.transform.localScale += growthAmount;
			yield return new WaitForSeconds(growthRate);
		}
		yield return null;
		
	}

	protected IEnumerator AgeCoroutines ()
	{
		
		yield return new WaitForSeconds(matureAge);
		ageStatus = AgeStatus.MATURE;
		EcosystemEntityHandler.entityDictionaryMature.Add (gameObject.name, gameObject);
		EcosystemEntityHandler.entityDictionary.Remove(gameObject.name);
		EcosystemEntityHandler.entityMatureCount++;
		
		yield return new WaitForSeconds(oldAge - matureAge);
		ageStatus = AgeStatus.OLD;
		EcosystemEntityHandler.entityDictionary.Add (gameObject.name, gameObject);
		EcosystemEntityHandler.entityDictionaryMature.Remove(gameObject.name);
		EcosystemEntityHandler.entityMatureCount--;
		
		yield return new WaitForSeconds(predictedDeath - oldAge);
		ageStatus = AgeStatus.DEAD;
		Death();
		yield return null;
		
		
	}
	
	
	public void Death()
	{
		
		Destroy (gameObject);
	}


}

