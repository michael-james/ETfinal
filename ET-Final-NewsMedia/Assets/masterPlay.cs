using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class masterPlay : MonoBehaviour {
	public int startOrig;
	public int endOrig;
	public masterBubble bub1script;
	public masterBubble bub2script;
	private int startPrev;
	private int endPrev;

	private bool open = false;
	private float angleLerp;
	private float posLerp;

	bool isTriggered = false;

	Vector3 bubCtrPos;
	GameObject bub1;
	GameObject bub2;
	Vector3 bub1OrigPos;
	Vector3 bub2OrigPos;

	private int toggleCount;

	public List<GameObject> bubbles = new List<GameObject>();

	// Use this for initialization
	void Start () {
		startOrig = 0;
		endOrig = 360;

		GameObject bubC = GameObject.Find("BubbleCenter");
		bubCtrPos = bubC.transform.position;

		bub1 = GameObject.Find("BubbleAuto1");
		bub1script = (masterBubble) bub1.GetComponent(typeof(masterBubble));
		bub1OrigPos = bub1.transform.position;
		bub2 = GameObject.Find("BubbleAuto2");
		bub2script = (masterBubble) bub2.GetComponent(typeof(masterBubble));
		bub2OrigPos = bub2.transform.position;

		toggleCount = 0;

		foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
		{
//			print(gameObj.name.Substring(0, 10));
			if ((gameObj.name.Length >= 10) && (gameObj.name.Substring(0, 10) == "BubbleAuto"))
			{
				bubbles.Add (gameObj);
			}
		}
		print(bubbles);
	}
	
	// Update is called once per frame
	void Update () {
		float inc = 0.005f;
		float posInc = 0.005f;

		if (open) {
			if (angleLerp < 1) {
				angleLerp += inc;
			}
			if (posLerp < 1) {
				posLerp += posInc;
			}
		} else {
			if (angleLerp > 0) {
				angleLerp -= inc;
			}
			if (posLerp > 0) {
				posLerp -= posInc;
			}
		}

		if (Input.GetKeyDown ("space")) {
			toggleAngle ();
		}

		if (Input.GetKeyDown ("r")) {
			rigid ();
		}

		var angleOff = (int)Mathf.Lerp (0, 90, angleLerp);
		var startNow = startOrig + angleOff;
		var endNow = endOrig - angleOff;
		if ((startNow != startPrev) || (endNow != endPrev)) {
			bub1script.updateAngle(startNow, endNow);
			bub1script.updateArticles ();
			bub2script.updateAngle(startNow, endNow);
			bub2script.updateArticles ();
		}

		startPrev = startNow;
		endPrev = endNow;

		bub1.transform.position = Vector3.Lerp (bub1OrigPos, bubCtrPos, posLerp);
		bub2.transform.position = Vector3.Lerp (bub2OrigPos, bubCtrPos, posLerp);
//		print (posLerp);
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

		toggleCount += 1;

		int rigidThresh = 5;
		print ("Toggle Count: " + toggleCount);
		if (toggleCount == rigidThresh) {
			rigid ();
		}
	}

	void rigid() {
		bub1script.addRigid ();
		bub2script.addRigid ();
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
