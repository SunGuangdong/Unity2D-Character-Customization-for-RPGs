using UnityEngine;
using System.Collections;

public class PositionForPlayer : MonoBehaviour {

	public GameObject PlayerPrefab;

	// Use this for initialization
	void Awake () 
	{
		GameObject player;

		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		if (players.Length == 0)
		{
			Debug.Log ("No Player in the Scene. Creating One!");
			player = Instantiate (PlayerPrefab);
		}
		else if (players.Length > 1) 
		{
			Debug.Log ("More than one player in the scene! Deleting all players and creating a new one!");
			foreach (GameObject pl in players)
				DestroyImmediate (pl.gameObject);
			player = Instantiate (PlayerPrefab);
		}
		else
		{
			player = players[0];
		}

		player.transform.position = transform.position;
		//Debug.Log(player.transform.position);	
	}

}
