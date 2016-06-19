using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
	public void LoadScene(string SceneName)
	{
		//Application.LoadLevel (SceneName);
		SceneManager.LoadScene (SceneName);
	}
}
