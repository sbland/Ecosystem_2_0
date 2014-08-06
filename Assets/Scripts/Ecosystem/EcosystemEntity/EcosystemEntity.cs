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

[System.Serializable]
public class AgeData{

	public int age = 0; // in Seconds
	public enum AgeStatus {DEFAULT,YOUNG, MATURE, OLD, DEAD};
	public AgeStatus ageStatus = AgeStatus.YOUNG;
	
	public int matureAge = 5; //age that reproduction is allowed
	public int oldAge = 7; // age that reproduction is stopped
	public int predictedDeath = 10;// int Seconds age that death is predicted

}

[System.Serializable]
public class GrowthData{
	
	public float growthRate = 1f;
	public Vector3 growthAmount = new Vector3 (); // vector to add to current size on growth
	public Vector3 initialScale = new Vector3(1,1,1);

}

[System.Serializable]
public class ChildData{
	
	public int maxChildrenPerYear = 5;
	public int currentChildrenPerYear = 0;
	
}


[System.Serializable]
public class AtmosphereData{
	
	public int oxygenOut = 0;
	public int coOut = 0;
}

public abstract class EcosystemEntity : MonoBehaviour
{
	public bool initialized = false;

	public AgeData ageData;
	public GrowthData growthData;
	public ChildData childData;
	public AtmosphereData atmosphereData;

	public EcosystemEntityHandler handler;
	public string uniqueName = "";
	public bool seedEnabled = true;
	public EcosystemTimeManager.Season seedSeason = EcosystemTimeManager.Season.SPRING;
	public bool affectsAtmosphere = true;


	protected void Aging ()
	{
		ageData.age +=1;
		
	}

	protected virtual IEnumerator Growing()
	{

		while (ageData.ageStatus != AgeData.AgeStatus.OLD) {
			gameObject.transform.localScale += growthData.growthAmount;
			yield return new WaitForSeconds(growthData.growthRate);
		}
		yield return null;
		
	}

	protected IEnumerator AgeCoroutines ()
	{

		yield return new WaitForSeconds(ageData.matureAge);
		ageData.ageStatus = AgeData.AgeStatus.MATURE;
			

		handler.entityDictionaryMature.Add (gameObject.name, gameObject);
		handler.entityDictionary.Remove(gameObject.name);
		handler.entityMatureCount++;
		
		yield return new WaitForSeconds(ageData.oldAge - ageData.matureAge);
		ageData.ageStatus = AgeData.AgeStatus.OLD;
		handler.entityDictionary.Add (gameObject.name, gameObject);
		handler.entityDictionaryMature.Remove(gameObject.name);
		handler.entityMatureCount--;
		
		yield return new WaitForSeconds(ageData.predictedDeath - ageData.oldAge);
		ageData.ageStatus = AgeData.AgeStatus.DEAD;
		Death();
		yield return null;
		
		
	}
	
	
	public void Death()
	{
		Destroy (gameObject);
	}

	void Awake()
	{
		//Reset
		gameObject.transform.localScale = growthData.initialScale;
		ageData.age = 0;
		ageData.ageStatus = AgeData.AgeStatus.YOUNG;
		
		
		//start updaters
		InvokeRepeating ("Aging", 1, 1);
		
		StartCoroutine (AgeCoroutines ());
		StartCoroutine (Growing ());
		
		
		//Randomize
		growthData.growthAmount.x += Random.Range (0, 0.001f);
		growthData.growthAmount.y += Random.Range (0, 0.001f);
		growthData.growthAmount.z += Random.Range (0, 0.001f);

		int deathRange = ageData.predictedDeath - ageData.oldAge;
		ageData.predictedDeath += Random.Range (-deathRange/3, deathRange/3);

		ChildAwake ();
	}

	void Start ()
	{
		if (!initialized) {
			OnEnableExtended ();
			initialized = true;
		}
		ChildStart ();
	}


	void OnEnable ()
	{
		if (initialized) {
			OnEnableExtended ();
		}

		ChildEnable ();
		
	}
	
	void OnDisable ()

	{
		Ecosystem.updateEcosystem -= EntityUpdate;
		
		handler.entityCount --;
		
		ChildDisable ();
	}

	void Update()
	{
		ChildUpdate ();
	}

	void FixedUpdate()
	{
		ChildFixedUpdate ();
	}

	public void OnEnableExtended ()
	{
		SetHandler ();
		name = uniqueName + handler.assignId;
		Ecosystem.updateEcosystem += EntityUpdate;
		handler.entityDictionary.Add (gameObject.name, gameObject);
		handler.entityCount ++;
	}

	
	public abstract void EntityUpdate ();
	public abstract void SetHandler();

	public virtual void ChildStart(){}
	public virtual void ChildAwake(){}
	public virtual void ChildEnable(){}
	public virtual void ChildDisable(){}
	public virtual void ChildUpdate(){}
	public virtual void ChildFixedUpdate(){}


}


