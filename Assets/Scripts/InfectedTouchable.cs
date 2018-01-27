using UnityEngine;
using VRTK;


public class InfectedTouchable : VRTK_InteractableObject
{
    public override void StartTouching(VRTK_InteractTouch currentTouchingObject = null)
    {
        base.StartTouching(currentTouchingObject);
        Debug.Log("i'm being infected");
    }

    public override void StopTouching(VRTK_InteractTouch previousTouchingObject = null)
    {
        base.StopTouching(previousTouchingObject);
        Debug.Log("i'm not touching anything infected");
    }
}
