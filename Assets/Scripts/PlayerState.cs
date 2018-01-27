using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
	InfectionStatus[] infectionStatuses;

	// Use this for initialization
	void Start ()
	{
		InfectionStatus[] infectionStatuses = FindObjectsOfType<InfectionStatus> ();
		foreach (InfectionStatus infectionStatus in infectionStatuses)
		{
			//infectionStatus.infectionChangeEvent.AddListener();
		}
	}
}
