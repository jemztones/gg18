using System.Collections;
using UnityEngine;

public class InfectionPoint : MonoBehaviour
{
	[SerializeField]
	int infectionAmount;

	[SerializeField]
	float infectionTick;

	InfectionStatus infectionStatus;

	Coroutine infectionCoroutine;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("i'm being infected");
		infectionStatus = other.gameObject.GetComponent<InfectionStatus> ();
		infectionCoroutine = StartCoroutine (InfectionTouchRoutine());
    }

	void OnTriggerExit()
	{
		if (infectionCoroutine != null)
		{
			Debug.Log("Stop infection coroutine");
			StopCoroutine (infectionCoroutine);
			infectionStatus = null;
			infectionCoroutine = null;
		}
	}

	IEnumerator InfectionTouchRoutine()
	{
		while (true)
		{
			infectionStatus.IncreaseInfectionLevel(infectionAmount);
			yield return new WaitForSeconds (infectionTick);
		}
	}
}
