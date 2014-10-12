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
using System.Collections.Generic;

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
	public Vector3 randomizeGrowth = new Vector3(0,0,0);

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

	public int oxygenRequirement = 0;
	public int coRequirement = 0;
}

/*---------------------------------------------------------------------------------------*/

public abstract class EcosystemEntity : MonoBehaviour
{
	public bool initialized = false;

	public AgeData ageData;
	public GrowthData growthData;
	public ChildData childData;
	public AtmosphereData atmosphereData;

	protected EcosystemEntityHandler handler;
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
			

		handler.dictionaryData.entityDictionaryMature.Add (gameObject.name, gameObject);
		handler.dictionaryData.entityDictionary.Remove(gameObject.name);
		handler.countData.entityMatureCount++;
		
		yield return new WaitForSeconds(ageData.oldAge - ageData.matureAge);
		ageData.ageStatus = AgeData.AgeStatus.OLD;
		handler.dictionaryData.entityDictionary.Add (gameObject.name, gameObject);
		handler.dictionaryData.entityDictionaryMature.Remove(gameObject.name);
		handler.countData.entityMatureCount--;
		
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
		Reset ();
		RandomizeDNA ();

		ChildAwake ();
	}

	void Start ()
	{
		if (!initialized) {
			OnEnableExtended ();

			if(handler.usePool)
			{
				handler.pool.pooledObjects = new List<GameObject> ();
				for (int i = 0; i < handler.pooledAmount; i++) {
					handler.pool.AddToPool(gameObject);
				}
			}

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
		if (initialized) {

			handler.countData.entityCount --;
		}
		Ecosystem.updateEcosystem -= EntityUpdate;
				
		CancelInvoke("Aging");
		StopCoroutine (AgeCoroutines ());
		StopCoroutine (Growing ());
		ChildDisable ();

		//Remove from atmosphere Data
		Ecosystem.atmosphere.OxygenCalc -= atmosphereData.oxygenOut;
		Ecosystem.atmosphere.CoCalc -= atmosphereData.coOut;
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
		SetHandler (); //Child classes set the handler class
		name = uniqueName + handler.assignId; //give entity a unique name
		Ecosystem.updateEcosystem += EntityUpdate;
		handler.dictionaryData.entityDictionary.Add (gameObject.name, gameObject);//add the entity to the list of entities in the class handler
		handler.countData.entityCount ++;

		//start updaters
		InvokeRepeating ("Aging", 1, 1);
		StartCoroutine (AgeCoroutines ());
		StartCoroutine (Growing ());

		//Add to Atmosphere Data
		Ecosystem.atmosphere.OxygenCalc += atmosphereData.oxygenOut;
		Ecosystem.atmosphere.CoCalc += atmosphereData.coOut;

	}

	void Reset()
	{
		gameObject.transform.localScale = growthData.initialScale;
		ageData.age = 0;
		ageData.ageStatus = AgeData.AgeStatus.YOUNG;
	}

	void RandomizeDNA()
	{
		//Randomize
		growthData.growthAmount += growthData.randomizeGrowth;
		
		int deathRange = ageData.predictedDeath - ageData.oldAge;
		ageData.predictedDeath += Random.Range (-deathRange/3, deathRange/3);

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


