using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.social;

public class FBUserConnect : MonoBehaviour {

	public static string fbAccessToken = "";
	public GUISkin Myskin;

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect (Screen.width/2 - 150, Screen.height/2 - 100, 300,300));
		GUILayout.BeginVertical();
		GUI.skin = Myskin;

		if	(GUILayout.Button("FACEBOOK CONNECT", GUILayout.Height(70),GUILayout.Width(300)))
		{	 
			 LoadingMessage.SetMessage("Connecting To Facebook...");
		     FacebookService.ConnectWithFacebook();
		}

		if	(GUILayout.Button("GLOBAL LEADERBOARD", GUILayout.Height(70),GUILayout.Width(300)))
		{	
			LoadingMessage.SetMessage("Please Wait...");
			FBLeaderBoard.GlobalLeaderBoard();
		}
		
		if	(GUILayout.Button("QUIT", GUILayout.Height(70),GUILayout.Width(300)))
		{
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
