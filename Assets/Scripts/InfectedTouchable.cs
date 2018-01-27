using System.Collections;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class InfectedTouchable : VRTK_InteractableObject
{
	[Header("Infection")]

	[SerializeField]
	int infectionAmount;

	[SerializeField]
	float infectionTick;

	[SerializeField]
	AudioSource audioSource;

	InfectionStatus infectionStatus;

	Coroutine infectionCoroutine;

    public override void StartTouching(VRTK_InteractTouch currentTouchingObject = null)
    {
		audioSource.Play ();
		infectionStatus = currentTouchingObject.GetComponent<InfectionStatus> ();
		if (infectionStatus)
		{
			infectionCoroutine = StartCoroutine(InfectionTouchRoutine());
		}
        base.StartTouching(currentTouchingObject);
        Debug.Log("i'm being infected");
    }

    public override void StopTouching(VRTK_InteractTouch previousTouchingObject = null)
    {
        base.StopTouching(previousTouchingObject);
        Debug.Log("i'm not touching anything infected");
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
			audioSource.Play ();
			infectionStatus.IncreaseInfectionLevel(infectionAmount);
			yield return new WaitForSeconds (infectionTick);
		}
	}
}
