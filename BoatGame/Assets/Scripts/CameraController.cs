using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	//public float smoothSpeed = 0.125f;
	public Vector3 offset;


	void start(){
		target = GameObject.FindGameObjectWithTag ("Cube").transform;
		offset = transform.position - target.position;
	}

	void Update(){
		transform.position = target.position + offset;
	}

	//void FixedUpdate()
	//{
	//	Vector3 desiredPosition = target.position + offset;
	//	Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
	//	transform.position = smoothedPosition;
	//
	//	transform.LookAt (target);
	//
	//}

}


