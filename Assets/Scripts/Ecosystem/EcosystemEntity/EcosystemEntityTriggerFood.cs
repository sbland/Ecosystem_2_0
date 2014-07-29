using UnityEngine;
using System.Collections;

public class EcosystemEntityTriggerFood : MonoBehaviour
{
	//Vector3 target;
	//bool nearFood = false; 

	private EcosystemEntity parentEntity;// = gameObject.name;//this.transform.parent.gameObject.GetComponent<EcosystemEntity>();
	
		// Use this for initialization
		void Start ()
		{
		parentEntity = gameObject.transform.parent.gameObject.GetComponent<EcosystemEntity> ();
		Debug.Log (parentEntity.entityName);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	void OnTriggerEnter (Collider active)
	{
		//check parent entity is set
		if (!parentEntity) {
			parentEntity = gameObject.transform.parent.gameObject.GetComponent<EcosystemEntity> ();
			Debug.Log (parentEntity.entityName);
				}
		float smoothing = 1f;
		
		if (active.GetComponent ("EcosystemEntity") != null) {
			Debug.Log ("HIT");

			EcosystemEntity hitObject = active.GetComponent<EcosystemEntity>();

			if(hitObject.entityName == parentEntity.foodGroupTargets[0])
			{
			//	parentEntity.nearFood = true;
			//	parentEntity.target = active.rigidbody.position;
			}

			if(General.SearchString(parentEntity.foodGroupTargets,hitObject.entityName))
			{
				Debug.Log("Food");
				parentEntity.nearFood = true;
				parentEntity.target = active.rigidbody;
				//Vector3 move = Vector3.Lerp(parentEntity.rigidbody.position, parentEntity.target, Time.deltaTime * smoothing);
				//parentEntity.rigidbody.MovePosition(move);
			}else{
				Debug.Log("not food!");
			}
			
		}
	}
	
	void OnTriggerExit (Collider active)
	{
		parentEntity.nearFood = false;
	}
}

