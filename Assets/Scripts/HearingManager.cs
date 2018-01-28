using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingManager : MonoBehaviour
{
	Ear[] ears;

	[SerializeField]
	List<MixerParamValuePair> muffleMixerParameters;

	[SerializeField]
	AudioSource heartbeatSource;

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
			heartbeatSource.Play ();
			foreach (MixerParamValuePair paramPair in muffleMixerParameters)
			{
				paramPair.exposedParameter.audioMixer.SetFloat (paramPair.exposedParameter.mixerVariableName, paramPair.value);
			}
		}
		else
		{
			Debug.Log ("Not all ears covered!");
			ResetMixerParams ();
		}
	}

	private void EarUncovered()
	{
		Debug.Log ("Ear no longer covered, re-enabling audio");
		ResetMixerParams ();
	}

	private void ResetMixerParams()
	{
		heartbeatSource.Stop ();
		foreach(MixerParamValuePair paramPair in muffleMixerParameters)
		{
			paramPair.exposedParameter.audioMixer.ClearFloat (paramPair.exposedParameter.mixerVariableName);
		}
	}
}
