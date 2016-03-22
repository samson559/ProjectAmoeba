using UnityEngine;
using System.Collections;

public class TimeyMctimer : MonoBehaviour {
	public float elapsed = 0.0f;
	public bool doStart = false;
	public UnityEngine.UI.Text textToWrite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (doStart) {
			elapsed += Time.deltaTime;
		}
	}
	public void dostart()
	{
		doStart = true;
	}
	public void stopAndReport()
	{
		doStart = false;
		textToWrite.text = "It took you "+elapsed+" seconds to push the button.";
	
	}
}
