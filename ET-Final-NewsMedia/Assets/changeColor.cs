using UnityEngine;
using System.Collections;

public class changeColor : MonoBehaviour {
//	public Color color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
	public Color lerpedColor = Color.white;

	// Use this for initialization
	void Start () {

	}
		
	// Update is called once per frame
	void Update () {
		lerpedColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));

		Renderer rend = GetComponent<Renderer>();
//		rend.material.shader = Shader.Find("Specular");
		rend.material.SetColor("_Color", lerpedColor);
	}
}