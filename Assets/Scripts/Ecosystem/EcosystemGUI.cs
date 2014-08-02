using UnityEngine;
using System.Collections;

public class EcosystemGUI : MonoBehaviour
{

	void OnGUI ()
	{

		GUI.TextArea (new Rect (20, 20, 200, 20), "Day: " + EcosystemTimeManager.day);
		GUI.TextArea (new Rect (20, 40, 200, 20), "Season: " + EcosystemTimeManager.season);
		GUI.TextArea (new Rect (20, 80, 200, 20), "Trees: " + EcosystemEntityTreeHandler.entityCount);
	}
}

