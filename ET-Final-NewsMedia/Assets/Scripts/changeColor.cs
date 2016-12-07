using UnityEngine;
using System.Collections;

public class changeColor : MonoBehaviour {
//	public Color color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
	public Color lerpedColor = Color.white;
	public float offset;

	// Use this for initialization
	void Start () {
		offset = Random.Range (0, 6);
	}
		
	// Update is called once per frame
	void Update () {
		lerpedColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(0.05f * Time.time + offset, 1));

		Renderer rend = GetComponent<Renderer>();
//		rend.material.shader = Shader.Find("Specular");
		rend.material.SetColor("_Color", lerpedColor);
	}
}