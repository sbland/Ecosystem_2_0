﻿/*************************************************************************
  Ecosystem Main Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Initializes Ecosystem

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#

	Rewriting Ecosystem

 ------------------------------------------------------------------------
 Contents
	1.	Imports
	2.	Variables
		2.1.	Adustable Variables
		2.2.	Rigidbodies
		2.3.	Settings
	3.	Standard Functions
		3.1. 	Start()
		3.2.	Update()
		3.3.	Initialization()
	4.	Unique Functions
		4.2.	EcosystemCalculations()
	5.	Debug functions
		5.1.	EcosystemConsoleLog()
		5.2.	EcosystemDataLog()
		
 *************************************************************************/




//1// IMPORTS
using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;




public class Ecosystem : MonoBehaviour {
	//2// VARIABLES
	//2.1// Input (User)
	public float updateRate = 10;
	public int updateCount = 0;


	//2.2// Rigidbodys
	
	//2.3// Directories
	public string saveLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Ecosystem";
	string logDir;

	//2.4// Objects
	public static EcosystemAtmosphere atmosphere;
	public static EcosystemEnvironment environment;
	public static EcosystemEntityHandler treeHandler;
	public static EcosystemEntityHandler humanHandler;
	public static EcosystemEntityHandler animalHandler;
	
	//2.5// Delegates
	
	public delegate void UpdateEcosystem ();
	public static event UpdateEcosystem updateEcosystem;


	//--------------------------------------------------------------------------------------------------------
	
	//3// STANDARD FUNCTIONS
	
	
	//3.1// Use this for initialization
	void Start () {


	}//End Start()--------------------------------------------------------------------------------------------------------

	void Awake () {
		Initialization ();
		
		try{
			File.WriteAllText (logDir, "Trees, Humans, Cow, Oxygen, CO2 \r\n");//Write column headers
		}catch{};	

	}//End Awake()--------------------------------------------------------------------------------------------------------


	
	//3.2//

	void Update () {
		EcosystemGUI ecosystemGUI = GetComponent<EcosystemGUI> ();
		if (Input.GetKeyDown (KeyCode.I)) {
			
						
						ecosystemGUI.enabled = true;
		} else if(Input.GetKeyUp (KeyCode.I)) {
			ecosystemGUI.enabled = false;
				}
	}//End Update()--------------------------------------------------------------------------------------------------------



	void OnEnable()
	{
		StartCoroutine (UpdateCoroutine());
		updateEcosystem += EcosystemCalculations;	
		updateEcosystem += EcosystemConsoleLog;
		updateEcosystem += EcosystemDataLog;
	}//End OnEnable()--------------------------------------------------------------------------------------------------------

	void OnDisable()
	{
		StopCoroutine (UpdateCoroutine());
		updateEcosystem -= EcosystemCalculations;	
		updateEcosystem -= EcosystemConsoleLog;
		updateEcosystem -= EcosystemDataLog;
	}//End OnDisable()--------------------------------------------------------------------------------------------------------





	IEnumerator UpdateCoroutine ()
	{
		yield return new WaitForSeconds(updateRate);
		while (this.enabled) {

			if (updateEcosystem != null){
				updateEcosystem();
			}
			yield return new WaitForSeconds(updateRate);
		}
		yield break;
	}//End UpdateCoroutine()--------------------------------------------------------------------------------------------------------



	//3.3//
	/// Initialize objects
	private void Initialization()
	{
		atmosphere = GetComponent<EcosystemAtmosphere> ();
		environment = GetComponent<EcosystemEnvironment> ();
		treeHandler = GetComponent<EcosystemEntityTreeHandler>();
		humanHandler = GetComponent<EcosystemEntityHumanHandler>();
		animalHandler = GetComponent<EcosystemEntityAnimalHandler>();

		logDir = saveLocation + "\\saveTest_" + System.DateTime.Now.ToString("HHmm_d_M_yy") + ".txt";
	}//End Update()--------------------------------------------------------------------------------------------------------

	//End Initialization()--------------------------------------------------------------------------------------------------------
	
	//4// UNIQUE FUNCTIONS

	//4.2//
	/// Ecosystems the calculations.
	void EcosystemCalculations()
	{
		Debug.Log ("EcoCalcs");
		atmosphere.AtmosphereCalcs ();
	}
	

	//5// DEBUG FUNCTIONS
	//5.1// console log.
	void EcosystemConsoleLog()
	{
	
	}
	
	//5.2//
	/// -Logs data to an xml file
	void EcosystemDataLog()
	{

		//File Write Test
		string dir = saveLocation + "\\saveTest.txt";
		//string printme = "";

		/*
		foreach (var item in EcosystemEntityData.entityDictionary) {
			printme +=  EcosystemEntityData.entityDictionary[item.Key].Count + ", ";
			
		}
		*/
		//printme += EcosystemEntityTreeHandler.entityCount + ", " + atmosphere.Oxygen + ", " + atmosphere.Co + "\r\n";
		//printme += treeHandler.countData.entityCount +  "\r\n";
		//
		//try{File.AppendAllText(logDir, printme);}catch{
		//		}

		string[] printme = {treeHandler.countData.entityCount + "", ", " + humanHandler.countData.entityCount, ", "+ animalHandler.countData.entityCount, ", " + atmosphere.Oxygen, ", " + atmosphere.Co + "\r\n"};
		for (int i = 0; i<printme.Length; i++) 
		{
			File.AppendAllText(logDir, printme[i]);
		}

	}
}
