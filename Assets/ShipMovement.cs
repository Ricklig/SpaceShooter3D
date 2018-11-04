using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        Vector3 finalDir = new Vector3(horizontal, vertical, 3.0f);

        transform.position += direction*moveSpeed*Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDir), Mathf.Deg2Rad* 30.0f);

	}
}
