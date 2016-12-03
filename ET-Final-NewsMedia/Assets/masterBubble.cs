using UnityEngine;
using System.Collections;

public class masterBubble : MonoBehaviour {
	// set number of articles
	public Object[] materials;
	public int articleCnt;
	public int angleStart;
	public int angleEnd;
	public double radius;
	private int totalArc;
	private int totalArcPrev;
	private float unitArc;
	public GameObject objToMake;
	private int levels;
	private float extraVal;
	public GameObject artPrnt;
	private bool alreadyRigid;

	// Use this for initialization
	void Start () {
		articleCnt = 16;
		radius = 1.4;
		angleStart = 0;
		angleEnd = 360;
		levels = 2;
		extraVal = 0f;
		updateAngle (angleStart, angleEnd);

		artPrnt = new GameObject("Articles");
		artPrnt.transform.parent = transform;

		materials = Resources.LoadAll("ProTrump/Materials");
//		print(materials.Length);
		createArticles ();

		alreadyRigid = false;

		//gameObject.renderer.material = myMaterials[random.Next(0,myMaterials.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateAngle (int start, int end) {
		angleStart = start;
		angleEnd = end;
		totalArc = angleEnd - angleStart;
		float inc = 0.1f;
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
//		print (totalArc + " " + extraVal + " " + extraShift + " " + unitArc);
		totalArcPrev = totalArc;
	}

	void createArticles () {
		for(int l = 0; l < levels; l++)
		{
			for(int o = 0; o < (articleCnt / 2); o++)
			{
				float myAngle = calcMyAngle (l, o);
				float d = setDepth(l, o);

				GameObject newArticle = Instantiate(
					objToMake,
					calcPos(myAngle, l, d),
					calcRot(myAngle),
					artPrnt.transform) as GameObject;
				newArticle.name = "article" + l + "" + o;
//				print (newArticle.transform.position);
				newArticle.GetComponent<articleVars> ().myDepth = d;
//				newArticle.transform.eulerAngles;
//				print ("myDepth" + newArticle.GetComponent<articleVars> ().myDepth);
//				newArticle.GetComponent<articleVars>().myDepth = d;
				Renderer rend = newArticle.GetComponent<Renderer>();
//				var index = (l * (articleCnt / 2)) + o;
//				rend.material.mainTexture = (Texture2D)textures[(l * (articleCnt / 2)) + o];

				Material material = (Material)materials[Random.Range(0, materials.Length)];
				rend.material = material;
			}
		}
	}

	public void updateArticles () {
		for(int l = 0; l < levels; l++)
		{
			for(int o = 0; o < (articleCnt / 2); o++)
			{
				Transform cArt = artPrnt.transform.GetChild (l * (articleCnt / 2) + o);

				float myAngle = calcMyAngle (l, o);
				float d = cArt.GetComponent<articleVars>().myDepth;

				cArt.transform.position = calcPos (myAngle, l, d);
				cArt.transform.rotation = calcRot (myAngle);
			}
		}
	}

	// article calculations

	float setDepth (int level, int order) {
		
		float artDepth = 0.5f;
		float myArtDepth = 0;
		if (level % 2 == 1) {
			if (order % 2 == 1) {
				myArtDepth = artDepth / 2 + Random.value * artDepth / 2;
			}
		} else {
			if (order % 2 == 0) {
				myArtDepth = artDepth / 2 + Random.value * artDepth / 2;
			}
		}
		return myArtDepth;
	}

	float calcMyAngle (int level, int order) {
		float myYRot = transform.eulerAngles.y;
		float myAngle = angleStart + unitArc * order + (level * (0.5f * unitArc)) + myYRot;
		return myAngle;
	}

	Vector3 calcPos (float myAngle, int level, float depth) {
		Vector3 mypos = transform.position;
		float btwnLevels = 0.65f;
//		print (depth);
		var opp = (float)(radius + depth) * Mathf.Sin ((float)myAngle * Mathf.Deg2Rad);
		var adj = (float)(radius + depth) * Mathf.Cos ((float)myAngle * Mathf.Deg2Rad);
		return new Vector3 (mypos.x + opp, mypos.y + level * btwnLevels, mypos.z + adj);
	}

	Quaternion calcRot (float myAngle) {
		return Quaternion.Euler(0, myAngle, 180);
	}

	public void addRigid() {
		if (alreadyRigid != true) {
			for (int l = 0; l < levels; l++) {
				for (int o = 0; o < (articleCnt / 2); o++) {
					GameObject cArt = artPrnt.transform.GetChild (l * (articleCnt / 2) + o).gameObject;
					Rigidbody gameObjectsRigidBody = cArt.AddComponent<Rigidbody> (); // Add the rigidbody.
//					gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.
				}
			}
		}

		alreadyRigid = true;
	}
}