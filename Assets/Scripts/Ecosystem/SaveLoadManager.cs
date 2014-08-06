using UnityEngine;
using System.Collections;
using System.Collections.Generic;//needed when using Lists

public class SaveLoadManager : MonoBehaviour {

	public List<int> intlist = new List<int>();
	string mystring = "";

	void Start()
	{
		foreach( int myint in intlist)
		{
			mystring = mystring+ "_" + myint.ToString();
		}

		//mystring.Split ("_");
	}
	//saving 

	public static void saveAnInt(int intToBeSaved)
	{
		PlayerPrefs.SetInt ("keyName", intToBeSaved);
	}

	public void saveAnString(string strgToBeSaved)
	{
		PlayerPrefs.SetString ("keyName2", strgToBeSaved);
	}

	//loading

	public int loadAnInt()
	{
		if (PlayerPrefs.HasKey ("keyName"))
		{
			return PlayerPrefs.GetInt ("keyName");
		} else {
			//either the key has not been reconized or it hasn't been set
			return -1;
		}
	}

	public string loadAnString()
	{
		if (PlayerPrefs.HasKey ("keyName2"))
		{
			return PlayerPrefs.GetString ("keyName2");
		} else {
			//either the key has not been reconized or it hasn't been set
			return "";
		}
	}

	// usage : SaveLoadManager.saveAnInt(2);
	//		: variable = SaveLoadManager.loadAnString();
}




