using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.social;

public class AppConstants : MonoBehaviour {

	public static string API_KEY = "<API_Key>";
	public static string SECRET_KEY = "<SECRET_KEY>";
	public static string gameName = "FBGlobalLeaderBoard";
	public static string collectionName = "FBUserDetails";
	public static string DB_NAME = "testDB";
	public static string FB_APP_ID = "<Facebook_AppId>";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static ScoreBoardService GetScoreService()
	{
		ScoreBoardService scoreboardService = App42API.BuildScoreBoardService ();
		return scoreboardService;
	}

	public static SocialService GetSocialService()
	{
		SocialService socialService = App42API.BuildSocialService ();
		return socialService;
	}
}
