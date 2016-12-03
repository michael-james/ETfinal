using UnityEngine;
using UnityEditor;
using System.Collections;

public class createMaterials : MonoBehaviour {
//	public Color color;

	public Object[] textures;

	// Use this for initialization
	void Start () {
		// Create a simple material asset

		Shader shader = Shader.Find ("Specular");
		textures = Resources.LoadAll("ProTrump/Textures");
//		print(textures.Length);

		for (int t = 0; t < textures.Length; t++) {
			Material material = new Material (shader);

			Texture2D texture = (Texture2D)textures [t];
			material.mainTexture = texture;
			material.name = texture.name;
			//		rend.material.color = color;

			AssetDatabase.CreateAsset (material, "Assets/Resources/ProTrump/Materials/" + material.name + ".mat");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
