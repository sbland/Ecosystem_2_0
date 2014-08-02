using UnityEngine;
using System.Collections;

public class EcosystemEntityTree : EcosystemEntity
{
	//User Input





	//private static Vector3 startScale;

	// Use this for initialization
	void Start ()
	{


	}

	void Awake()
	{
		//Reset
		gameObject.transform.localScale = initialScale;
		age = 0;
		ageStatus = AgeStatus.YOUNG;

		name = uniqueName + EcosystemEntityTreeHandler.assignId;

		InvokeRepeating ("Aging", 1, 1);

		StartCoroutine (AgeCoroutines ());
		StartCoroutine (Growing ());



		growthAmount.x += Random.Range (0, 0.001f);
		growthAmount.y += Random.Range (0, 0.001f);
		growthAmount.z += Random.Range (0, 0.001f);

		int deathRange = predictedDeath - oldAge;

		predictedDeath += Random.Range (-deathRange/3, deathRange/3);
	
	}


	void OnEnable ()
	{
		Ecosystem.updateEcosystem += EntityUpdate;
		EcosystemEntityTreeHandler.entityDictionary.Add (gameObject.name, gameObject);
		EcosystemEntityTreeHandler.entityCount ++;

	}

	void OnDisable ()

	{
		Ecosystem.updateEcosystem -= EntityUpdate;

		EcosystemEntityTreeHandler.entityCount --;


	}


	// Update is called once per frame
	void Update ()
	{

	}

	//Called at during Ecosystem update
	public void EntityUpdate()
	{

	}







}

