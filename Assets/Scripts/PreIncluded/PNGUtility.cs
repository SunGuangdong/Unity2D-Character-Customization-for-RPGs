using UnityEngine;
using System.Collections;
using System.IO;

public static class PNGUtility
{

	public static Sprite LoadSpriteFromFile(string path, int width, int height)
	{
		if (System.IO.File.Exists (path)) 
		{
			byte[] bytes = File.ReadAllBytes (path);
			Texture2D texture = new Texture2D (width, height);
			texture.filterMode = FilterMode.Trilinear;
			texture.LoadImage (bytes);
			Sprite sprite = Sprite.Create (texture, new Rect (0, 0, width, height), new Vector2 (0.5f, 0.0f), 1.0f);
			return sprite;
		}
		else 
			return null;
	}

	public static void SaveRenderTextureToFile(string filePath, RenderTexture rt)
	{
		// get contents of RenderTexture to Texture2D
		Texture2D tempTexture = new Texture2D (rt.width, rt.height);
		RenderTexture.active = rt;
		tempTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
		tempTexture.Apply();

		// write Texture2D to a file
		byte[] bytes;
		bytes = tempTexture.EncodeToPNG ();

		System.IO.File.WriteAllBytes (filePath, bytes);

		RenderTexture.active = null;
	}
}
