using UnityEngine;
using System.Collections;

public class MyGame : MonoBehaviour {

	public static double scoreValue = 100;
	public GUISkin GameSkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = GameSkin;
		GUILayout.BeginArea(new Rect (Screen.width/2 - 150, Screen.height/2 - 100, 500,500));
		GUILayout.BeginVertical();
		GUILayout.Label ("Your Score : "+ scoreValue,GUILayout.Width(400),GUILayout.Height(100));
		if	(GUILayout.Button("Click Me! To Increase Score...", GUILayout.Height(70),GUILayout.Width(400)))
		{
			scoreValue += 100;
		}
		
		if	(GUILayout.Button("Kill Me, Save My Score !!!" , GUILayout.Height(70),GUILayout.Width(400)))
		{	
			FBLeaderBoard.SaveScore();
		}

//		if	(GUILayout.Button("LEADERBOARD AMONG FACEBOOK FRIENDS", GUILayout.Height(70),GUILayout.Width(300)))
//		{
//			FBLeaderBoard.FriendsLeaderBoard();
//		}
//
//		if	(GUILayout.Button("LEADERBOARD AMONG FACEBOOK USERS", GUILayout.Height(70),GUILayout.Width(300)))
//		{
//			FBLeaderBoard.GlobalLeaderBoard();
//		}

		if	(GUILayout.Button("QUIT", GUILayout.Height(70),GUILayout.Width(400)))
		{
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
