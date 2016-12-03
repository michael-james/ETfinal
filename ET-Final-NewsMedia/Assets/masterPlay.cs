using UnityEngine;
using System.Collections;

public class masterPlay : MonoBehaviour {
	public int bubstartOrig;
	public int bubendOrig;
	public masterBubble bub1script;
	public masterBubble bub2script;
	private int bub1startPrev;
	private int bub1endPrev;
	private int bub2startPrev;
	private int bub2endPrev;

	// Use this for initialization
	void Start () {
		bubstartOrig = 0;
		bubendOrig = 360;

		GameObject bub1 = GameObject.Find("BubbleAuto1");
		bub1script = (masterBubble) bub1.GetComponent(typeof(masterBubble));
//		GameObject bub2 = GameObject.Find("BubbleAuto2");
//		bub2script = (masterBubble) bub2.GetComponent(typeof(masterBubble));

	}
	
	// Update is called once per frame
	void Update () {
		var t = Mathf.Abs(Mathf.Sin((float)0.01 * Time.frameCount));
		var angleOff = (int)Mathf.Lerp (0, 90, t);
		var bub1start = bubstartOrig + angleOff;
		var bub1end = bubendOrig - angleOff;
//		var bub1start = bubstartOrig;
//		var bub1end = bubendOrig;
//
//		print (angleOff + " " + bub1start + " " + bub1end);
//		print (Time.deltaTime);
//		print (bub1end);
		if ((bub1start != bub1startPrev) || (bub1end != bub1endPrev)) {
			bub1script.updateAngle(bub1start, bub1end);
			bub1script.updateArticles ();
		}

		bub1startPrev = bub1start;
		bub1endPrev = bub1end;

//		var bub2start = bubstartOrig + angleOff;
//		var bub2end = bubendOrig - angleOff;
////		print (angleOff + " " + bub2start + " " + bub2end);
//		//		print (Time.deltaTime);
//		//		print (bub1end);
//		if ((bub2start != bub2startPrev) || (bub2end != bub2endPrev)) {
//			bub2script.updateAngle(bub2start, bub2end);
//			bub2script.updateArticles ();
//		}
//
//		bub2startPrev = bub1start;
//		bub2endPrev = bub1end;
	}
}
