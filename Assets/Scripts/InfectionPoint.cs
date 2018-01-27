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
		infectionStatus = other.gameObject.GetComponentInChildren<InfectionStatus> ();
        if (infectionStatus)
        {
            Debug.Log("i'm being infected");
            infectionCoroutine = StartCoroutine(InfectionTouchRoutine());
        }
        else
        {
            Debug.Log("no infection status on touching object " + other.gameObject.name);
        }
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
