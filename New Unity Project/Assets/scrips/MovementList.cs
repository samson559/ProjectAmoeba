
using UnityEngine;
using System.Collections;
using UnityEditor;

public class MovementList : MonoBehaviour {
	private float journey;
	private float distCovered;
	private float rate;
	public Transform[] marks;
	public float[] times;
	private int which;
	bool reached;
	IEnumerator co;
	pair curr;
	// Use this for initialization
	void Start () {
		//init movement
		if (marks.Length != times.Length) {
			throw new  System.Exception("YOU IDIOT");
		}
		curr = new pair(times[0],marks[0]);
		reached = false;
		//do we wait here or go nex?
		
		if (curr.where == null) {
			co = wait ();
		} else {
			
			journey = Vector3.Distance (transform.position, curr.where.position);
			co = move(curr.where,curr.time);
		}
		//start moving/waiting
		StartCoroutine(co);

	}
	
	// Update is called once per frame
	void Update () {
		if (reached) {
			which++;
			if(which<marks.Length)
			{
				curr = new pair(times[which],marks[which]);
				reached = false;
				
				if (curr.where == null) {
					co = wait ();
				} else {
					
					journey = Vector3.Distance (transform.position, curr.where.position);
					co = move(curr.where,curr.time);
				}
				StartCoroutine(co);
			}

		}


	}

	IEnumerator move(Transform ms,float t2move)
	{

		while (!reached) {
			//if we arrived, then start going to next
			if(ms!=null){
				float speed = journey / t2move;
				//distCovered = (Time.time - start) * speed;
				if(GetComponent<SpriteRenderer> ().bounds.Contains(ms.position)&&!reached)
				{
					reached = true;
					StopCoroutine(co);
				}
				rigidbody2D.AddForce (Vector3.Normalize (ms.position - transform.position) * speed);
				yield return null;
			}

		}
	}
	IEnumerator wait()
	{
		while (!reached) {
			//print (curr.time);
			curr.time -= Time.deltaTime;
			if (curr.time < 0) {
				reached = true;
				StopCoroutine (co);
			}
			yield return null;
		}
	}
	/*
	 * convenient way of pairing times and transforms
	 */
	private class pair
	{
		public float time;
		public Transform where;
		public pair(float t,Transform w)
		{
			time = t;
			where = w;
		}
	}


}
