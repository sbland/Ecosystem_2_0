using UnityEngine;
using System.Collections;

public struct EcosystemEntityStruct
{
	public enum AgeStatus {DEFAULT,YOUNG, MATURE, OLD, DEAD};

}




public interface IEcosystemEntity
{
	int age{ get; set; }

	EcosystemEntityStruct.AgeStatus ageStatus{ get; set; }
	/*
	
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
	*/

}

