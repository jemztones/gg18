using UnityEngine;
using VRTK;

public class Ear : VRTK_InteractableObject
{
	[Header("Ear")]

	[ReadOnly]
	[SerializeField]
	bool covered = false;

	[SerializeField]
	AudioListener listener;

	public override void StartTouching(VRTK_InteractTouch currentTouchingObject = null)
	{
		Debug.Log ("covered ear");
		covered = true;
		listener.enabled = false;
		base.StartTouching(currentTouchingObject);
	}

	public override void StopTouching(VRTK_InteractTouch previousTouchingObject = null)
	{
		Debug.Log ("uncovered ear");
		covered = false;
		listener.enabled = true;
		base.StopTouching(previousTouchingObject);
	}
}
