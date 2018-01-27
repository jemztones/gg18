using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class InfectedTouchable : VRTK_InteractableObject
{
	[Header("Infection")]

	[SerializeField]
	AudioSource audioSource;

    public override void StartTouching(VRTK_InteractTouch currentTouchingObject = null)
    {
		audioSource.Play ();
        base.StartTouching(currentTouchingObject);
        Debug.Log("i'm being infected");
    }

    public override void StopTouching(VRTK_InteractTouch previousTouchingObject = null)
    {
        base.StopTouching(previousTouchingObject);
        Debug.Log("i'm not touching anything infected");
    }
}
