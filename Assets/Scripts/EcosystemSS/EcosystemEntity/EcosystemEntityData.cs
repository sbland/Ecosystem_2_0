/*************************************************************************
  Ecosystem Entity Data holder
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:02/03/14
  Description: Holds information/data on number of entities and the current growth rate

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

public class EcosystemEntityData : MonoBehaviour
{
	public int updateRate = 200;
	private int updateCount = 0;

	public float sensitivity = 1; // global sensitivity effector

	//Data Class stores information for an ecosystem entity type
	public class Data
	{

		public int Count = 0;
		public float m_growthRate = 1;	//chance of Growth 1 = always , 0 = never
		public float m_birthRate = 1;	//chance of birth 1 = always , 0 = never
		public float m_deathRate = 1;	//chance of death 1 = always , 0 = never

		public float m_coChange = 0;
		public float m_oxygenChange = 0;

		//Requirements - Optimal Environment requirements 
		public float m_oxygenReq = 0;
		public float m_coReq = 0;
		
		public float m_tempReq = 0;
		
		public float m_growthScale = 1;
		
		public int m_updateRate = 500;
		public int m_updateCount = 0;

		public Data()
		{
			
		}

		public Data(int countIn, float growthIn, float birthIn, float deathIn)
		{
			Count = countIn;
			m_growthRate = growthIn;
			m_birthRate = birthIn;
			m_deathRate = deathIn;
		}

		public Data(int updateRate, 
		            float growthScale, 
		            float coChange, 
		            float oxygenChange,
		            float oxygenReq,
		            float coReq,
		            float tempReq
		            )
		{
			m_updateRate = updateRate;
			m_growthScale = growthScale;
			m_coChange = coChange;
			m_oxygenChange = oxygenChange;
			m_oxygenReq = oxygenReq;

			m_coReq = coReq;

			m_tempReq = tempReq;

				
		}
		
		
	}
	
	public static int registeredCount = 0;


	public static Dictionary<string, Data> entityDictionary = new Dictionary<string, Data>();

		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
			if (updateCount == updateRate) {
						foreach (var item in entityDictionary) {
								EcoCalculations (item.Key);
						
						}
						updateCount = 0;
				} else {
						updateCount++;
				}
		}






	
	public void EcoCalculations(string item)
	{
		Data itemD = entityDictionary [item];


		float oxygenRatio;
		float coRatio;
		//float tempRatio;

		oxygenRatio = Ecosystem.atmosphere.Oxygen / entityDictionary [item].m_oxygenReq;
		coRatio = Ecosystem.atmosphere.Co / entityDictionary [item].m_coReq;
		//tempRatio = Ecosystem.environment.Temperature / entityDictionary [item].m_tempReq;

		entityDictionary [item].m_birthRate = negExp (oxygenRatio) * negExp (coRatio);// * negExp(tempRatio);
		entityDictionary [item].m_growthRate = entityDictionary [item].m_birthRate / 2;
		entityDictionary [item].m_deathRate = Mathf.Max(posExp (oxygenRatio),posExp (coRatio));// * posExp (tempRatio);

		//entityDictionary [item] = itemD;



	}

	public float negExp(float varExp)
	{
		varExp = varExp * sensitivity;
		return 1 - Mathf.Exp (-varExp);
	}
	public float posExp (float varExp)
	{
		varExp = varExp * sensitivity;
		return Mathf.Exp (-varExp);
	}


}

