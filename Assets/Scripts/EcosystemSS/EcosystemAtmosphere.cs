/*************************************************************************
  Ecosystem Atmosphere Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Controls atmosphere systems

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#

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

public class EcosystemAtmosphere : MonoBehaviour
{
	public float m_oxygen; 	//O2
	public float m_co;			//CO2
	private static float m_nitrogen;	//N2
	private static float m_argon;		//Ar
	private static float m_neon;		//Ne
	private static float m_helium;		//He
	private static float m_methane;	//CH4
	private static float m_hydrogen;	//Ar
	private static float m_krypton;	//Ar

	public float m_oxygenCalc = 0;
	public float m_coCalc = 0;


	public	float OxygenCalc
	{
		get
		{
			return m_oxygenCalc;
		}
		set
		{
			m_oxygenCalc = value;
			
		}
	}public	float CoCalc
	{
		get
		{
			return m_coCalc;
		}
		set
		{
			m_coCalc = value;
		}
	}


	public	float Co
	{
		get
		{
			return m_co;
		}
		set
		{
			if(value>=1f){
				m_co = value;
			}else{
				m_co = 1f;
			}

		}
	}

	public	float Oxygen
	{
		get
		{
			return m_oxygen;
		}
		set
		{
			if(value>=1f){
				m_oxygen = value;
			}else{
				m_oxygen = 1f;
			}
		}
	}

	public	float Nitrogen
	{
		get
		{
			return m_nitrogen;
		}
		set
		{
			if(value>=0)
			{
			m_nitrogen = value;
			}
		}
	}
	
	public	float Argon
	{
		get
		{
			return m_argon;
		}
		set
		{
			if(value>=0)
			{
			m_argon = value;
			}
		}
	}

	public	float Neon
	{
		get
		{
			return m_neon;
		}
		set
		{
			m_neon = value;
		}
	}

	public	static float Helium
	{
		get
		{
			return m_helium;
		}
		set
		{
			m_helium = value;
		}
	}

	public	static float Methane
	{
		get
		{
			return m_methane;
		}
		set
		{
			m_methane = value;
		}
	}

	public	static float Hydrogen
	{
		get
		{
			return m_hydrogen;
		}
		set
		{
			m_hydrogen = value;
		}
	}

	public	static float Krypton
	{
		get
		{
			return m_krypton;
		}
		set
		{
			m_krypton = value;
		}
	}

	
	public sealed class Units
	{
		public static readonly string Oxygen = "% Oxygen";
		public static readonly string Co = "% Co2";
		public static readonly string Nitrogen = "% Nitrogen";
		public static readonly string Argon = "% Argon";
		public static readonly string Neon = "% Neon";
		public static readonly string Helium = "% Helium";
		public static readonly string Methane = "% Methane";
		public static readonly string Hydrogen = "% Hydrogen";
		public static readonly string Krypton = "% Krypton";
		
	}
}


	
