using UnityEngine;
using System.Collections;

public class masterBubble : MonoBehaviour {
	// set number of articles
	public Material[] myMaterials = new Material[12];
	public int articleCnt;
	public int angleStart;
	public int angleEnd;
	public int radius;
	private int totalArc;
	private double unitArc;
	public GameObject objToMake;

	// Use this for initialization
	void Start () {
		articleCnt = myMaterials.Length;
		angleStart = 0;
		angleEnd = 360;
		radius = 2;
		updateAngle (angleStart, angleEnd);
		int levels = 2;

		for(int i = 0; i < levels; i++)
		{
			for(int j = 0; j < (articleCnt / 2); j++)
			{
				createArticle (i, j);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {


		//gameObject.renderer.material = myMaterials[random.Next(0,myMaterials.Length)];
	}

	public void updateAngle (int start, int end) {
		angleStart = start;
		angleEnd = end;
		totalArc = angleEnd - angleStart;
		unitArc = 1.0 * totalArc / ((articleCnt / 2) - 1);
//		print ("new!");
//		print (articleCnt);
//		print (totalArc);
//		print (unitArc);
	}

	void createArticle (int level, int order) {
		double myAngle = unitArc * order;
		print (myAngle);

		var o = radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
		var a = radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);

//		transform.localPosition = new Vector3(0, 0, 0);
		var mypos = this.transform.position;
//		print (mypos);
		print ("o: " + o + ", a:" + a);
		print ("x: " + (mypos.x + o) + ", y:" + mypos.y + 2.0f + ", z:" + mypos.z + a);
		Instantiate(objToMake, new Vector3(mypos.x + o, mypos.y + level * 1.0f, mypos.z + a), Quaternion.identity, this.transform);
	}
}