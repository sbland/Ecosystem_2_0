using UnityEngine;
using System.Collections;

public class EcosystemGUI : MonoBehaviour
{

	void OnGUI ()
	{

		GUI.TextArea (new Rect (20, 20, 200, 20), "Day: " + EcosystemTimeManager.day);
		GUI.TextArea (new Rect (20, 40, 200, 20), "Season: " + EcosystemTimeManager.season);
		GUI.TextArea (new Rect (20, 80, 200, 20), "Trees: " + Ecosystem.treeHandler.countData.entityCount);
		GUI.TextArea (new Rect (20, 100, 200, 20), "Humans: " + Ecosystem.humanHandler.countData.entityCount);
		GUI.TextArea (new Rect (20, 120, 200, 20), "Animals: " + Ecosystem.animalHandler.countData.entityCount);

		GUI.TextArea (new Rect (20, 160, 200, 20), "Co: " + Ecosystem.atmosphere.Co);
		GUI.TextArea (new Rect (20, 180, 200, 20), "Oxygen: " + Ecosystem.atmosphere.Oxygen);
		GUI.TextArea (new Rect (20, 200, 200, 20), "CoOut: " + Ecosystem.atmosphere.CoCalc);
		GUI.TextArea (new Rect (20, 220, 200, 20), "OxygenOut: " + Ecosystem.atmosphere.OxygenCalc);



	}
}

