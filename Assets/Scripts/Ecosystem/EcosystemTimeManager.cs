using UnityEngine;
using System.Collections;

public class EcosystemTimeManager : MonoBehaviour
{

	public static int day;
	[Range(1, 365)] public int setDay = 1;


	public enum Season {SPRING, SUMMER, AUTUMN, WINTER};
	public static Season season;
	
	
	
	
	
	// Use this for initialization
	void Start ()
	{
		day = setDay;
		setSeason (day);
		Ecosystem.updateEcosystem += NextDay;

	}
	
	// Update is called once per frame
	void Update ()
	{
		setDay = day;
	}

	public void setSeason(int dayOfYear)
	{
		if(dayOfYear >= 1 && dayOfYear < 45)
		{
			season = Season.WINTER;
		}else if(dayOfYear >= 45 && dayOfYear < 137)
		{
			season = Season.SPRING;
		}else if(dayOfYear >= 137 && dayOfYear < 228)
		{
			season = Season.SUMMER;
		}else if(dayOfYear >= 228 && dayOfYear < 319)
		{
			season = Season.AUTUMN;
		}else if(dayOfYear >= 319)
		{
			season = Season.WINTER;
		}
	}

	public void NextDay()
	{
		if (day < 366) {
			day++;
		}else{day = 1;}

		if (day == 45) {
			season = Season.SPRING;
		} else if (day == 137) {
			season = Season.SUMMER;
		} else if (day == 228) {
			season = Season.AUTUMN;
		} else if (day == 319) {
			season = Season.WINTER;
		}
	}
}

