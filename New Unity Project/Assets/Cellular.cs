using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody2D))]
public class Cellular : MonoBehaviour {
	private Vector3 originalscale;
	public float maxDeformation = 2.0f;

	// Use this for initialization
	void Start () {
		originalscale = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {
		squish ();
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
