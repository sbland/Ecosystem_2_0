using UnityEngine;
using System.Collections;

public class General
{
	public static bool SearchString(string[] stringArray, string stringIn)
	{
		bool check = false;
		foreach(string i in stringArray)
		{
			if (stringIn == i)
			{
				check =  true;
			}
		}
		return check;
	}
}

