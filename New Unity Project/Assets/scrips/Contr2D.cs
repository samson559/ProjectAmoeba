using UnityEngine;
using System.Collections;

public class Contr2D : MonoBehaviour {
	public float speed = 5.0F;
	public float maxDeformation = 2.0f;
	public float dart= 10.0F;
	private Vector2 direction = Vector2.zero;
	private Vector3 originalscale;
	// Use this for initialization
	void Start () {
		originalscale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		direction=new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"))*speed;
		rigidbody2D.AddForce (direction);
		if (Input.GetButtonDown ("Jump"))
			rigidbody2D.AddForce (dart * direction);
		//eggWhite.transform.position = gameObject.transform.position;
		squish ();
	}
	public void updateMotion()
	{
	}
	private void squish()
	{
		//rotate towards direction of travel.
		float zrot = Mathf.Rad2Deg*Mathf.Atan2(rigidbody2D.velocity.y,rigidbody2D.velocity.x);
		transform.localEulerAngles = new Vector3(0,0,zrot);
		//squish
		float yscale = Mathf.Abs(Vector3.Magnitude(Vector3.ClampMagnitude(rigidbody2D.velocity,maxDeformation)));
		this.transform.localScale = new Vector3 (originalscale.x+yscale,originalscale.y, originalscale.x);
		//print (yscale);
		//print (zrot);
	}
}
