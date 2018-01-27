using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour {
	float timeCounter=0;

	public float speed;
	public float width;
	public float height;

	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		speed = 1;
		width = 60;
		height = 5;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime*speed;

		float x = Mathf.Cos (timeCounter)*width;
		float y = 0;
		float z = Mathf.Sin (timeCounter)*height;
		
		transform.position = new Vector3 (x, y, z) + startPos;
	
	}
}
