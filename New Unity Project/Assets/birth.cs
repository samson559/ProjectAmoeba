using UnityEngine;
using System.Collections;

public class birth : MonoBehaviour {
	public GameObject baby;
	public float gestation;
	public float fracSize;
	public float initSize;
	public float ejectRate;
	public Color babytone;
	private bool mature;
	public bool fertile;
	private IEnumerator co;
	private float start;
	private float now;
	private float growthRate;
	// Use this for initialization
	void Start () {
		co = makeBaby ();
		start = Time.time;
		growthRate = fracSize / gestation;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("b")&&fertile)
			StartCoroutine (co);
	}
	IEnumerator makeBaby()
	{
		print ("called");
		baby = (GameObject)Instantiate (baby);
		baby.collider2D.enabled = false;
		baby.transform.parent = this.transform;
		baby.rigidbody2D.isKinematic = false;
		baby.transform.localPosition = new Vector3(0,0,-.2f);
		baby.transform.localScale = Vector3.one * initSize;
		baby.GetComponent<SpriteRenderer> ().color = Color.red;
		while (!(baby.transform.localScale.x>fracSize)) {
			baby.transform.localScale += Vector3.one*(growthRate);
			print (Time.time-start);
			if(baby.transform.localScale.x>fracSize)
			{
				mature = true;
				baby.transform.parent = null;
				baby.transform.position = new Vector3(baby.transform.position.x,baby.transform.position.y,0);

				baby.rigidbody2D.isKinematic = false;
				baby.rigidbody2D.AddForce(Vector3.one*ejectRate);

				baby.collider2D.enabled = true;

				StopCoroutine(co);
			}
			yield return null;
		}
	}
}
