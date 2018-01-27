using UnityEngine;
using System.Collections;

public class HoverEffect : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public float amplitude;

	private Vector3 tempPosition;

	// Use this for initialization
	void Start () {

		tempPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		tempPosition.x += horizontalSpeed;
		tempPosition.y = Mathf.Sin (Time.realtimeSinceStartup * verticalSpeed) * amplitude;
		tempPosition.y += 1;
		transform.position = tempPosition;
			}
}
