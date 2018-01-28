using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingManager : MonoBehaviour
{
	Ear[] ears;

	[SerializeField]
	AudioListener listener;

	void Start()
	{
		ears = FindObjectsOfType<Ear>();
		foreach (Ear ear in ears)
		{
			ear.coveredEvent.AddListener (EarCovered);
			ear.uncoveredEvent.AddListener (EarUncovered);
		}
	}

	private void EarCovered()
	{
		bool allCovered = true;
		foreach (Ear ear in ears)
		{
			if (!ear.covered)
			{
				allCovered = false;
				break;
			}
		}

		if (allCovered)
		{
			Debug.Log ("All ears covered!");
			listener.enabled = false;
		}
		else
		{
			Debug.Log ("Not all ears covered!");
			listener.enabled = true;
		}
	}

	private void EarUncovered()
	{
		Debug.Log ("Ear no longer covered, re-enabling audio");
		listener.enabled = true;
	}
}
