using UnityEngine;
using System.Collections;

public class contr : MonoBehaviour {
	public float speed = 5.0F;
	public float jumpHeight = 5.0F;
	public float gravScale = 5.0F;
	private GameObject eggWhite;
	Vector3 direction = Vector3.zero;
	// Use this for initialization
	void Start () {
		//Physics.IgnoreCollision (GetComponent<Collider> (), transform.parent.GetComponent<Collider> ());
		eggWhite = transform.Find ("eggWhite").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		direction=new Vector3(Input.GetAxis("Horizontal")*speed,0,Input.GetAxis("Vertical")*speed);
		rigidbody.AddForce (direction);
		//eggWhite.transform.position = gameObject.transform.position;
		if (Input.GetKeyDown("space")) {

			Vector3 location = transform.position+.5f*eggWhite.renderer.bounds.extents;
			Instantiate(eggWhite,location,Quaternion.identity);
		}
	}
}
