//using Kino;
using UnityEngine;
using UnityEngine.PostProcessing;

public class InfectedVision : MonoBehaviour
{
	[SerializeField]
	Camera viewCamera;

	[SerializeField]
	PostProcessingBehaviour postProcBehaviour;

	[SerializeField]
	float edgeOfScreenAdjustment;

	//[SerializeField]
	//Slitscan slitscan;

	float minVal;
	float maxVal;

	void Start()
	{
		maxVal = 1.0f - edgeOfScreenAdjustment;
		minVal = 0.0f + edgeOfScreenAdjustment;
	}

	void Update()
	{
		// TEMP while we adjust the balance during play
		maxVal = 1.0f - edgeOfScreenAdjustment;
		minVal = 0.0f + edgeOfScreenAdjustment;

		Vector3 viewPos = viewCamera.WorldToViewportPoint(transform.position);

		bool visible = false;
		if (GetComponent<Renderer>().IsVisibleFrom (viewCamera))
		{
			Debug.Log ("In camera coordinates");
			if (viewPos.x >= minVal && viewPos.x <= maxVal &&
			    viewPos.y >= minVal && viewPos.y <= maxVal)
			{
				//Debug.Log ("Visible  x: " + viewPos.x + " y: " + viewPos.y);
				RaycastHit hit;
				Vector3 rayDirection = transform.position - viewCamera.transform.position;

				if (Physics.Raycast (viewCamera.transform.position, rayDirection, out hit))
				{
					if (hit.transform.gameObject == gameObject)
					{
						Debug.Log ("Raytrace hit me: " + viewPos.x + " y: " + viewPos.y);
						visible = true;
					}
					else
					{
						Debug.Log ("Raytrace blocked by " + hit.transform.gameObject.name);
					}
				}
				else
				{
					Debug.Log ("Raytrace hit nothing");
				}
			}
			else
			{
				Debug.Log ("Visible from cam but not onscreen x: " + viewPos.x + " y: " + viewPos.y);
			}
		}
		else
		{
			Debug.Log ("Not visiblen x: " + viewPos.x + " y: " + viewPos.y);
		}

		if (visible)
		{
			//slitscan.enabled = true;
			//postProcBehaviour.enabled = true;
		}
		else
		{
			//slitscan.enabled = false;
			//postProcBehaviour.enabled = false;
		}
	}
}
