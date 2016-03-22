using UnityEngine;
using System.Collections;

public class Contr2D : MonoBehaviour {
	public float speed = 5.0F;
	public float dart= 10.0F;
	private Vector2 direction = Vector2.zero;
	private Vector3 originalscale;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		direction=new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"))*speed;
		rigidbody2D.AddForce (direction);
		if (Input.GetButtonDown ("Jump"))
			rigidbody2D.AddForce (dart * direction);
		//eggWhite.transform.position = gameObject.transform.position;
	}
}
