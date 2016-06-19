using UnityEngine;
using System;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	public BodyPartManager[] AllBodyParts;

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.HasKey ("LastCharName"))
			LoadCharacterFromConf (PlayerPrefs.GetString ("LastCharConfiguration"));
	}

	public string CurrentConfiguration()
	{
		string conf = "";
		foreach (BodyPartManager bpm in AllBodyParts) 
		{
			conf += bpm.IndexOfWornItem.ToString ();
			conf += "/";
		}
		return conf;
	}

	public void LoadCharacterFromConf(string conf)
	{
		string[] indexesString = conf.Split ('/');
		for (int i = 0; i < indexesString.Length - 1; i++)
			AllBodyParts [i].IndexOfWornItem = Int32.Parse (indexesString [i]);
	}

}
