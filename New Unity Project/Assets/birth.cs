using UnityEngine;
using System.Collections;

public class birth : MonoBehaviour {
	private GameObject baby;
	public GameObject babyType;
	public float gestation;
	public float fracSize;
	public float initSize;
	public float ejectRate;
	public Color babytone;
	private bool doBirth;
	public bool fertile;
	private IEnumerator co;
	private float start;
	private float now;
	private float growthRate;


	int callcount = 0;
	// Use this for initialization
	void Start () {
		start = Time.time;
		growthRate = fracSize / gestation;
		baby = null;

	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown ("b") && fertile) {
			baby = (GameObject)Instantiate (babyType);
			
			baby.transform.parent = this.transform;
			baby.transform.localPosition = new Vector3(0,0,-.1f);
			
			baby.rigidbody2D.isKinematic = true;
			baby.collider2D.enabled = false;
			
			//superimpose
			baby.transform.localScale = Vector3.one * initSize;
			baby.GetComponent<SpriteRenderer> ().color = Color.red;
			baby.GetComponent<birth> ().enabled = false;

			doBirth = true;
		}
		if (doBirth) {
			baby.transform.localScale+=(Vector3.one*(growthRate*Time.deltaTime));
			if(baby.transform.localScale.magnitude>fracSize) {
				doBirth = false;
				baby.transform.position = new Vector3(baby.transform.position.x,baby.transform.position.y,0);
				
				baby.rigidbody2D.isKinematic = false;
				baby.rigidbody2D.AddForce(Vector3.one*ejectRate);
				
				baby.collider2D.enabled = true;
				baby.transform.parent = null;
			}
		}
	}
	IEnumerator makeBaby()
	{
		baby = (GameObject)Instantiate (babyType);

		baby.transform.parent = this.transform;
		baby.transform.localPosition = new Vector3(0,0,-.1f);

		baby.rigidbody2D.isKinematic = true;
		baby.collider2D.enabled = false;

		//superimpose
		baby.transform.localScale = Vector3.one * initSize;
		baby.GetComponent<SpriteRenderer> ().color = Color.red;
		baby.GetComponent<birth> ().enabled = false;
	
		while (baby.transform.localScale.magnitude<fracSize) {
			baby.transform.localScale+=Vector3.one;
			/*
		

			if(baby.transform.localScale.x>fracSize)
			{
				callcount++;
				print ("birthing   "+callcount);
				mature = true;
				baby.transform.position = new Vector3(baby.transform.position.x,baby.transform.position.y,0);

				baby.rigidbody2D.isKinematic = false;
				baby.rigidbody2D.AddForce(Vector3.one*ejectRate);

				baby.collider2D.enabled = true;

			}*/
yield return null;
			
		}
		baby.transform.parent = null;

		StopCoroutine(co);


	}
}
