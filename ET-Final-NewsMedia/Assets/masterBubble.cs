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
	public int levels;

	// Use this for initialization
	void Start () {
		articleCnt = myMaterials.Length;
		angleStart = 0;
		angleEnd = 360;
		radius = 1;
		updateAngle (angleStart, angleEnd);
		levels = 2;

		createArticle ();
	}
	
	// Update is called once per frame
	void Update () {
//		updateArticles ();

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

	void createArticle() {
		for(int i = 0; i < levels; i++)
		{
			for(int j = 0; j < (articleCnt / 2); j++)
			{
				Place myPlace = new Place (i, j);

//				print ("level: " + i + ", order: " + j + ", position: " + myPlace.pos + ", rotation: " + myPlace.rot.eulerAngles);

//				print (this.transform);

				float myAngle = unitArc * j + (i * (unitArc / 2)) + this.transform.eulerAngles.y;

				var o = (float)radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
				var a = (float)radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);

				var newArticle = Instantiate(objToMake,
					new Vector3 (o, i * 1.0f, a),
					Quaternion.Euler (0, myAngle + Mathf.PI / 2, Mathf.PI / 2),
					transform);
				newArticle.name = "article" + i + "" + j;

//				var newArticle = Instantiate(objToMake,
//					myPlace.pos,
//					myPlace.rot,
//					transform);
//				newArticle.name = "article" + i + "" + j;
			}
		}
	}

	public void updateArticles () {
		print ("no");

		for(int i = 0; i < levels; i++)
		{
			for(int j = 0; j < (articleCnt / 2); j++)
			{
				Transform cArt = this.gameObject.transform.GetChild (i * (articleCnt / 2) + j);

				Place myPlace = new Place (i, j);

				cArt.transform.position = myPlace.pos;//new Vector3 (o, level * 1.0f, a);
				cArt.transform.rotation = myPlace.rot;//Quaternion.Euler (0, myAngle + Mathf.PI / 2, Mathf.PI / 2);
			}
		}
	}
		

	class Place {
		public Vector3 pos;
		public Quaternion rot;

	 	public Place (int level, int order) {
//			GameObject bub1 = GameObject.Find("BubbleAuto1");
//			var bub1script = (masterBubble) bub1.GetComponent(typeof(masterBubble));


//			var unitArc = bub1script.unitArc;
//			var radius = bub1script.radius;
			var unitArc = 1.0f * 360 / ((12 / 2));
			var radius = 1;

			float myAngle = unitArc * order + (level * (unitArc / 2));

			var o = (float)radius * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
			var a = (float)radius * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);

			pos = new Vector3 (o, level * 1.0f, a);
			rot = Quaternion.Euler (0, myAngle + Mathf.PI / 2, Mathf.PI / 2);
		}
	}
}