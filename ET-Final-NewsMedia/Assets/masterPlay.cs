using UnityEngine;
using System.Collections;

public class masterPlay : MonoBehaviour {
	public int bub1start;
	public int bub1end;
	public masterBubble bub1script;
	private int bub1startPrev;
	private int bub1endPrev;

	// Use this for initialization
	void Start () {
		bub1start = 0;
		bub1end = 360;

		GameObject bub1 = GameObject.Find("BubbleAuto1");
		bub1script = (masterBubble) bub1.GetComponent(typeof(masterBubble));

	}
	
	// Update is called once per frame
	void Update () {
		if ((bub1start != bub1startPrev) || (bub1end != bub1endPrev)) {
//			bub1script.updateAngle(bub1start, bub1end);
//			bub1script.updateArticles();
		}

		bub1startPrev = bub1start;
		bub1endPrev = bub1end;
	}
}
