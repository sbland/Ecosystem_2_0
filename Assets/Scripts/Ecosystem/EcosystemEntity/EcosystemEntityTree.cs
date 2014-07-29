using UnityEngine;
using System.Collections;

public class EcosystemEntityTree : MonoBehaviour
{
	//User Input
	public int age = 0; // in Seconds
	public int matureAge = 5; //age that reproduction is allowed
	public int oldAge = 7; // age that reproduction is stopped
	public int predictedDeath = 10;// int Seconds age that death is predicted
	public Vector3 growthAmount = new Vector3 (); // vector to add to current size on growth
	public float growthRate = 1f;
	public string uniqueName = "";
	public enum AgeStatus {DEFAULT,YOUNG, MATURE, OLD, DEAD};
	public AgeStatus ageStatus = AgeStatus.YOUNG;

	//private static Vector3 startScale;

	// Use this for initialization
	void Start ()
	{


	}

	void Awake()
	{

		gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		age = 0;
		ageStatus = AgeStatus.YOUNG;

		name = uniqueName + EcosystemEntityTreeHandler.assignId;

		InvokeRepeating ("Aging", 1, 1);
		StartCoroutine (AgeCoroutines ());
		StartCoroutine (Growing ());

		growthAmount.x += Random.Range (0, 0.001f);
		growthAmount.y += Random.Range (0, 0.001f);
		growthAmount.z += Random.Range (0, 0.001f);
	
	}


	void OnEnable ()
	{
		Ecosystem.updateEcosystem += EntityUpdate;
		EcosystemEntityTreeHandler.treeDictionary.Add (gameObject.name, gameObject);
		EcosystemEntityTreeHandler.treeCount ++;

	}

	void OnDisable ()

	{
		Ecosystem.updateEcosystem -= EntityUpdate;

		EcosystemEntityTreeHandler.treeCount --;


	}


	// Update is called once per frame
	void Update ()
	{

	}

	//Called at during Ecosystem update
	public void EntityUpdate()
	{

	}


	IEnumerator AgeCoroutines ()
	{

		yield return new WaitForSeconds(matureAge);
		ageStatus = AgeStatus.MATURE;
		EcosystemEntityTreeHandler.treeDictionaryMature.Add (gameObject.name, gameObject);
		EcosystemEntityTreeHandler.treeDictionary.Remove(gameObject.name);
		EcosystemEntityTreeHandler.treeMatureCount++;

		yield return new WaitForSeconds(oldAge - matureAge);
		ageStatus = AgeStatus.OLD;
		EcosystemEntityTreeHandler.treeDictionary.Add (gameObject.name, gameObject);
		EcosystemEntityTreeHandler.treeDictionaryMature.Remove(gameObject.name);
		EcosystemEntityTreeHandler.treeMatureCount--;

		yield return new WaitForSeconds(predictedDeath - oldAge);
		ageStatus = AgeStatus.DEAD;
		death ();
		yield return null;


	}

	void Aging ()
	{
		age +=1;

	}

	IEnumerator Growing()
	{
		//gameObject.renderer.material.color = new Color(ageRatio, 0,0);
		while (ageStatus != AgeStatus.OLD) {
			gameObject.transform.localScale += growthAmount;
			yield return new WaitForSeconds(growthRate);
				}
		yield return null;

	}
	

	public void death()
	{

		Destroy (gameObject);
	}

}

