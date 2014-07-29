using UnityEngine;
using System.Collections;

public class EcosystemEnvironment : MonoBehaviour
{
	public float m_temperature;
	public float m_humidity;

		public float  Temperature
		{
			get
			{
				return m_temperature;
			}
			set
			{
				m_temperature = value;
			}
		}
	public float Humidity
		{
			get
			{
				return m_humidity;
			}
			
			set
			{
				m_humidity = value;
			}
		}
	                    
	public sealed class Units
	{
		public static readonly string Temperature = "°C Temperature";
		public static readonly string Humidity = "% Humidity";
	}
}



