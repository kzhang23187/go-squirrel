using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour {

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)){
			Debug.Log("mouse down");
		} else{

			Move();
		}
	}

	void Move(){
		Vector3 lastPosition = transform.position;
		transform.position = new Vector3(lastPosition.x + speed * Time.deltaTime, lastPosition.y, lastPosition.z);
	}
}
