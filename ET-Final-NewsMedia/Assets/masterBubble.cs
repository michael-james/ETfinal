using UnityEngine;
using System.Collections;

public class masterBubble : MonoBehaviour {
	// set number of articles
	public Material[] myMaterials = new Material[12];
	public int articleCnt;
	public int angleStart;
	public int angleEnd;
	public double radius;
	private int totalArc;
	private int totalArcPrev;
	private float unitArc;
	public GameObject objToMake;
	private int levels;
	private float extraVal = 0f;

	// Use this for initialization
	void Start () {
		articleCnt = 12; //myMaterials.Length;
		angleStart = 0;
		angleEnd = 360;
		radius = 2.75;
		updateAngle (angleStart, angleEnd);
		levels = 2;

		createArticles ();

		//gameObject.renderer.material = myMaterials[random.Next(0,myMaterials.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateAngle (int start, int end) {
		angleStart = start;
		angleEnd = end;
		totalArc = angleEnd - angleStart;
		float inc = 0.05f;
		if ((totalArc < 360) && (extraVal <= (1 + inc)) && (totalArc < totalArcPrev)) {
			extraVal = extraVal + inc;
//			print ("over!");
		} else {
			if (extraVal >= inc) {
				extraVal = extraVal - inc;
			} else {
			// do nothing
			}
		}
		var extraShift = Mathf.Lerp (0, 0.5f, extraVal);
		unitArc = 1.0f * totalArc / ((articleCnt / 2) - extraShift);
		print (totalArc + " " + extraVal + " " + extraShift + " " + unitArc);
		totalArcPrev = totalArc;
	}

	void createArticles () {
		for(int l = 0; l < levels; l++)
		{
			for(int o = 0; o < (articleCnt / 2); o++)
			{
				float myAngle = calcMyAngle (l, o);

				var newArticle = Instantiate(
					objToMake,
					calcPos(myAngle, l),
					calcRot(myAngle),
					this.transform);
				newArticle.name = "article" + l + "" + o;
			}
		}
	}

	public void updateArticles () {
		for(int l = 0; l < levels; l++)
		{
			for(int o = 0; o < (articleCnt / 2); o++)
			{
				Transform cArt = this.gameObject.transform.GetChild (l * (articleCnt / 2) + o);

				float myAngle = calcMyAngle (l, o);

				cArt.transform.position = calcPos (myAngle, l);
				cArt.transform.rotation = calcRot (myAngle);
			}
		}
	}

	// article calculations

	float calcMyAngle (int level, int order) {
		float myYRot = transform.eulerAngles.y;
		float myAngle = angleStart + unitArc * order + (level * (unitArc / 2) + myYRot);
		return myAngle;
	}

	Vector3 calcPos (float myAngle, int level) {
		Vector3 mypos = transform.position;

		var opp = (float)radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
		var adj = (float)radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);
		return new Vector3 (mypos.x + opp, mypos.y + level * 1.0f, mypos.z + adj);
	}

	Quaternion calcRot (float myAngle) {
		return Quaternion.Euler(+ 0, myAngle + Mathf.PI/2, Mathf.PI/2);
	}
}