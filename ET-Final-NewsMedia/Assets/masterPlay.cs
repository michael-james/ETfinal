using UnityEngine;
using System.Collections;

public class masterPlay : MonoBehaviour {
	public int bubstartOrig;
	public int bubendOrig;
	public masterBubble bub1script;
	private int bub1startPrev;
	private int bub1endPrev;

	private bool open;
	private float lerpVal;

	bool isTriggered = false;

	// Use this for initialization
	void Start () {
		bubstartOrig = 0;
		bubendOrig = 360;

		GameObject bub1 = GameObject.Find("BubbleAuto1");
		bub1script = (masterBubble) bub1.GetComponent(typeof(masterBubble));
	}
	
	// Update is called once per frame
	void Update () {
		float inc = 0.1f;

		if (open) {
			if (lerpVal > 0) {
				lerpVal -= inc;
			}
		} else {
			if (lerpVal < 1) {
				lerpVal += inc;
			}
		}

		if (Input.GetKeyDown ("space")) {
			toggleAngle ();
		}

		var angleOff = (int)Mathf.Lerp (0, 90, lerpVal);
		var bub1start = bubstartOrig + angleOff;
		var bub1end = bubendOrig - angleOff;
		if ((bub1start != bub1startPrev) || (bub1end != bub1endPrev)) {
			bub1script.updateAngle(bub1start, bub1end);
			bub1script.updateArticles ();
		}

		bub1startPrev = bub1start;
		bub1endPrev = bub1end;
	}

	void LateUpdate () {
		GvrViewer.Instance.UpdateState();
		HandleTrigger();
		if (isTriggered)
			toggleAngle ();
	}

	private void HandleTrigger() {
		// If trigger isn't already held.
		if (!isTriggered) {
			if (GvrViewer.Instance.Triggered || Input.GetMouseButtonDown(0)) {
				// Trigger started.
				isTriggered = true;
			}
		}
		else if (!GvrViewer.Instance.Triggered && !Input.GetMouseButton(0)) {
			// Trigger ended.
			isTriggered = false;
		}
	}

	void toggleAngle() {
		if (open) {
			open = false;
		} else {
			open = true;
		}
	}

//	void scratch () {
//		var t = Mathf.Abs(Mathf.Sin((float)0.01 * Time.frameCount));
//		var angleOff = (int)Mathf.Lerp (0, 90, t);
//		var bub1start = bubstartOrig + angleOff;
//		var bub1end = bubendOrig - angleOff;
//		//		var bub1start = bubstartOrig;
//		//		var bub1end = bubendOrig;
//		//
//		//		print (angleOff + " " + bub1start + " " + bub1end);
//		//		print (Time.deltaTime);
//		//		print (bub1end);
//		if ((bub1start != bub1startPrev) || (bub1end != bub1endPrev)) {
//			bub1script.updateAngle(bub1start, bub1end);
//			bub1script.updateArticles ();
//		}
//
//		bub1startPrev = bub1start;
//		bub1endPrev = bub1end;
//
//		//		var bub2start = bubstartOrig + angleOff;
//		//		var bub2end = bubendOrig - angleOff;
//		////		print (angleOff + " " + bub2start + " " + bub2end);
//		//		//		print (Time.deltaTime);
//		//		//		print (bub1end);
//		//		if ((bub2start != bub2startPrev) || (bub2end != bub2endPrev)) {
//		//			bub2script.updateAngle(bub2start, bub2end);
//		//			bub2script.updateArticles ();
//		//		}
//		//
//		//		bub2startPrev = bub1start;
//		//		bub2endPrev = bub1end;
}
