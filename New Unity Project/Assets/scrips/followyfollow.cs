using UnityEngine;
using System.Collections;

public class followyfollow : MonoBehaviour {
	public GameObject thing;
	public float adjust;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (thing.transform.position != this.transform.position) {
			transform.position=Vector3.Lerp(transform.position,thing.transform.position,adjust);
		}

		print ("me "+transform.position);
		print ("thing "+thing.transform.position);

	}
}
