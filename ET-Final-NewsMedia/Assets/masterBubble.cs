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
	private float unitArc;
	public GameObject objToMake;

	// Use this for initialization
	void Start () {
		articleCnt = myMaterials.Length;
		angleStart = 0;
		angleEnd = 360;
		radius = 1;
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
		unitArc = 1.0f * totalArc / ((articleCnt / 2));
//		print ("new!");
//		print (articleCnt);
//		print (totalArc);
//		print (unitArc);
	}

	void createArticle (int level, int order) {
		float myAngle = unitArc * order + (level * (unitArc / 2));
		print (myAngle);

		print (radius);
		var o = (float)radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
		var a = (float)radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);

//		transform.localPosition = new Vector3(0, 0, 0);
		var mypos = this.transform.position;
//		print (mypos);
//		print ("o: " + o + ", a:" + a);
//		print ("x: " + (mypos.x + o) + ", y:" + mypos.y + 2.0f + ", z:" + mypos.z + a);
		var newArticle = Instantiate(objToMake, new Vector3(mypos.x + o, mypos.y + level * 1.0f, mypos.z + a), Quaternion.Euler(0, myAngle + Mathf.PI/2, Mathf.PI/2), this.transform);
		newArticle.name = "article" + level + "" + order;
	}
}