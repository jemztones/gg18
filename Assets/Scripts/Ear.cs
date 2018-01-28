using UnityEngine;
using UnityEngine.Events;
using VRTK;

public class Ear : VRTK_InteractableObject
{
	[Header("Ear")]

	[ReadOnly]
	public bool covered = false;

	public UnityEvent coveredEvent;
	public UnityEvent uncoveredEvent;

	public override void StartTouching(VRTK_InteractTouch currentTouchingObject = null)
	{
		Debug.Log ("covered ear");
		covered = true;
		coveredEvent.Invoke ();
		base.StartTouching(currentTouchingObject);
	}

	public override void StopTouching(VRTK_InteractTouch previousTouchingObject = null)
	{
		Debug.Log ("uncovered ear");
		covered = false;
		uncoveredEvent.Invoke ();
		base.StopTouching(previousTouchingObject);
	}
}
