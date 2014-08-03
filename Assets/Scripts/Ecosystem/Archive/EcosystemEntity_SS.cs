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

public class EcosystemEntity_SS : MonoBehaviour
{
	//properties
	//Atmosphere
	public float m_coChange = 0f;	//amount to add to global per second Co change
	public float m_oxygenChange = 0f; //amount to add to global per second Oxygen change

	//Requirements
	public float oxygenReqUpper = 0f;  
	public float coReqUpper = 0f;
	public float tempReq = 0f;

	//Food
	public string[] foodGroupTargets;	//List of foods this entity eats
	public string foodGroup = "";	//food group of entity

	//Growth
	public float growthAmount = 1f;	//Growth speed adjustment constant

	//Update speed
	public int updateRate = 500; //Number of frames between updates
	public int updateCount = 0;	//Initial update frame count
	public int adjustment = 1;	//Entity balance adjustment (Higher values increase population growth speed)

	public string entityName = null;

	public bool registered = false;

	public Rigidbody target;
	public bool nearFood = false; //Switch to indicate food has entered vicinity


	//Report
	public float thisBirthRate = 0;
	public float thisDeathRate = 0;

	//property methods

	public float CoChange {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
		}
	}
	
	public float OxygenChange {
		get{
			return m_oxygenChange;
		}
		set{
			m_oxygenChange = value;		
		}
	}
	
	//3// STANDARD FUNCTIONS
	
	
	//3.1// Use this for initialization
	void Start () {

		//UpdateCount ();
		updateCount = Random.Range (0, updateRate);
		gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

		//Register entity to collection
		if (!registered) {
			Register();
			EcosystemEntityData.entityDictionary [entityName].Count++;
			Ecosystem.atmosphere.OxygenCalc += this.m_oxygenChange;
			Ecosystem.atmosphere.CoCalc += this.m_coChange;
		} else {
			EcosystemEntityData.entityDictionary [entityName].Count++;
			Ecosystem.atmosphere.OxygenCalc += this.m_oxygenChange;
			Ecosystem.atmosphere.CoCalc += this.m_coChange;
		}
	}//End Start()--------------------------------------------------------------------------------------------------------
	
	//3.2//
	// Update is called once per frame
	void Update () {
		/*
		if(nearFood)	//checks if near food tag is true. If true moves entity towards target food
		{
			//Vector3 target = new Vector3(0,0,100f);
			Vector3 move = Vector3.Lerp(rigidbody.position, target.position, Time.deltaTime * 1f);
			rigidbody.MovePosition(move);
		}
		*/
		//this.UpdateExtra ();
	}//End Update()--------------------------------------------------------------------------------------------------------

	public void UpdateExtra () {}

	void FixedUpdate(){
		
		//EntityCounts();
		if (updateCount == updateRate) 
		{
			updateCount = 0;
			EcoCalculations ();	
		}
		updateCount++;

		
	}

	//4.1//
	public void EcoCalculations()
	{

		thisBirthRate = EcosystemEntityData.entityDictionary [entityName].m_birthRate;

		int seed = Random.Range (1, 10 * adjustment);
		if (chanceConvert (EcosystemEntityData.entityDictionary [entityName].m_birthRate, seed)) {
			if (chanceConvert (EcosystemEntityData.entityDictionary [entityName].m_birthRate, seed)) {
				Debug.Log ("Create " + entityName);
				Create ();
			}else{
				Debug.Log ("Grow " + entityName);
				Growth();
			}
		
		} 
		else if (chanceConvert (EcosystemEntityData.entityDictionary [entityName].m_deathRate, seed)) {
				Debug.Log ("Remove " + entityName);
				Remove ();
		}


	}

	// weighted true or false check
	public static bool chanceConvert(float inputChance, int seed)
	{
		inputChance = inputChance * 10;

		if (seed > inputChance) {
			Debug.Log ("False ");
			return false;
		}else{
			
			Debug.Log ("True ");
			return true;
		}
	}

		
	//4.2//
	public void Register()
	{
		EcosystemEntityData.Data newData = new EcosystemEntityData.Data (updateRate,
		                                                                 growthAmount,
		                                                                 m_coChange,
		                                                                 m_oxygenChange,
		                                                                 oxygenReqUpper,
		                                                                 coReqUpper,
		                                                                 tempReq
		                                                                 );
		EcosystemEntityData.entityDictionary.Add (entityName, newData);
		EcosystemEntityData.registeredCount++;
		
		registered = true;
	}
	
	//4.3//
	public bool Create()
	{

		Rigidbody newInstance;
		Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
		newInstance = MonoBehaviour.Instantiate (gameObject, gameObject.rigidbody.position + position, gameObject.rigidbody.rotation) as Rigidbody;
		return true;

	}

	//4.4//
	public bool Remove()
	{
		EcosystemEntityData.entityDictionary [entityName].Count--;
		Ecosystem.atmosphere.OxygenCalc -= m_oxygenChange;
		Ecosystem.atmosphere.CoCalc -= m_coChange;

		MonoBehaviour.Destroy (gameObject);
		return true;
	}


	//4.5//
	public void Growth()
	{
		Debug.Log ("Growth");
		gameObject.rigidbody.transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f);
	}

}

