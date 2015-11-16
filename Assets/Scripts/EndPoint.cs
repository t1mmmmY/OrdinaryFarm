using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour 
{

	void OnTriggerEnter(Collider other) 
	{
		CowMind cow = other.GetComponent<CowMind>();
		if (cow != null)
		{
			cow.ReachTheDestination();
		}
	}

}
