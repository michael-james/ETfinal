using UnityEngine;
using System.Collections;

public class masterBubble3 : MonoBehaviour {
	// set number of articles
	public Material[] myMaterials = new Material[12];
	public int articleCnt;
	public int angleStart;
	public int angleEnd;
	public double radius;
	private int totalArc;
	private float unitArc;
	public GameObject objToMake;
	//	public int levels;

	// Use this for initialization
	void Start () {
		articleCnt = myMaterials.Length;
		angleStart = 0;
		angleEnd = 360;
		radius = 1;
		updateAngle (angleStart, angleEnd);
		var levels = 2;

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
	}

	void createArticle (int level, int order) {
		float myAngle = unitArc * order + (level * (unitArc / 2));
		var o = (float)radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
		var a = (float)radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);

		var newArticle = Instantiate(
			objToMake,
			new Vector3(o, level * 1.0f, a),
			Quaternion.Euler(0, myAngle + Mathf.PI/2, Mathf.PI/2),
			this.transform);
		newArticle.name = "article" + level + "" + order;
	}

	//	public void updateArticles () {
	//		print ("no");
	//
	//		for(int i = 0; i < levels; i++)
	//		{
	//			for(int j = 0; j < (articleCnt / 2); j++)
	//			{
	//				Transform cArt = this.gameObject.transform.GetChild (i * (articleCnt / 2) + j);
	//
	//				float myAngle = unitArc * j + (i * (unitArc / 2));
	//				var o = (float)radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
	//				var a = (float)radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);
	//
	//				cArt.transform.position = new Vector3 (o, i * 1.0f, a);
	//				cArt.transform.rotation = Quaternion.Euler (0, myAngle + Mathf.PI / 2, Mathf.PI / 2);
	//			}
	//		}
	//	}
}