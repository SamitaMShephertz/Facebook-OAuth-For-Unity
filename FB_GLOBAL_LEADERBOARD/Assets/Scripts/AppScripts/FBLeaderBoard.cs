using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.social;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp.storage;

public class FBLeaderBoard : MonoBehaviour {

	static ScoreBoardService scoreBoardService = null;
	//static SocialService socialService = null;
	public static bool  errorMessage   =false;
	public static string exceptionMessage;
	public GUISkin Myskin;
	private Vector2 scrollPosition = Vector2.zero;
	public static string kk = "dddd";
	public static Dictionary <string , object> dist = new Dictionary<string, object>();


	// Use this for initialization
	void Start () {
		scoreBoardService = App42API.BuildScoreBoardService ();
	//	socialService = App42API.BuildSocialService ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI()
	{
		GUI.skin = Myskin;
		GUILayout.BeginArea(new Rect (Screen.width/2 - 250, Screen.height/2 - 240, 800,1000));
		GUILayout.BeginVertical();
		//GUI.skin = Myskin;

		GUILayout.Box ("LEADERBOARD", GUILayout.Width (500), GUILayout.Height (50));

		GUILayout.BeginHorizontal ();
		GUILayout.Space (20);
		GUILayout.Label ("Rank", GUILayout.Width (130), GUILayout.Height (50));
		GUILayout.Label ("ProfilePic", GUILayout.Width (150), GUILayout.Height (50));
		GUILayout.Label ("Name", GUILayout.Width (150), GUILayout.Height (50));
		GUILayout.Label ("Score", GUILayout.Width (150), GUILayout.Height (50));
		GUILayout.EndHorizontal ();
		GUILayout.BeginScrollView (scrollPosition,GUILayout.Height(300),GUILayout.Width(650));
		for(int i = 0; i< FriendsLeaderBoardCallBack.GetList().Count; i++)
		{
			IList<string> details = (IList<string>)FriendsLeaderBoardCallBack.GetList()[i];
			string userName = details[1].ToString();
			string score = details[3].ToString();
			int rank = i+1;
		
			GUILayout.BeginHorizontal ();
			GUILayout.Space (20);
			GUILayout.Label (rank.ToString(), GUILayout.Width (150), GUILayout.Height (100));
			if(dist.ContainsKey(details[0].ToString())){
			 Texture2D pp = (Texture2D)dist[details[0].ToString()];
			 GUILayout.Label (pp, GUILayout.Width (120), GUILayout.Height (100));
			}
			GUILayout.Label (userName, GUILayout.Width (170), GUILayout.Height (100));
			GUILayout.Label (score, GUILayout.Width (150), GUILayout.Height (100));
			GUILayout.EndHorizontal ();
		}
		for(int i = 0; i< LeaderBoardCallBack.GetList().Count; i++)
		{
			IList<string> details = (IList<string>)LeaderBoardCallBack.GetList()[i];
			string userName = details[1].ToString();
			string score = details[3].ToString();
			int rank = i+1;
			
			GUILayout.BeginHorizontal ();
			GUILayout.Space (20);
			GUILayout.Label (rank.ToString(), GUILayout.Width (150), GUILayout.Height (100));
			if(dist.ContainsKey(details[0].ToString())){
				Texture2D pp = (Texture2D)dist[details[0].ToString()];
				GUILayout.Label (pp, GUILayout.Width (120), GUILayout.Height (100));
			}
			GUILayout.Label (userName, GUILayout.Width (170), GUILayout.Height (100));
			GUILayout.Label (score, GUILayout.Width (150), GUILayout.Height (100));
			GUILayout.EndHorizontal ();
		}

		GUILayout.EndScrollView ();

		GUILayout.BeginArea (new Rect (120, 400, 300,100));
		GUILayout.BeginVertical ();
		if	(GUILayout.Button("Friends LeaderBoard", GUILayout.Height(50),GUILayout.Width(300)))
		{
			OnlyFriendsLeaderBoard();
		}
		if	(GUILayout.Button("HOME", GUILayout.Height(50),GUILayout.Width(300)))
		{
			Application.LoadLevel("MainScene");
		}
		GUILayout.EndVertical ();
		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect (130, 230, 460,60));
		if(errorMessage)
		{
			GUIStyle myButtonStyle1 = new GUIStyle (GUI.skin.label);
			myButtonStyle1.fontStyle = FontStyle.Bold;			
			myButtonStyle1.fontSize = 18;
			GUILayout.Label( exceptionMessage , myButtonStyle1,GUILayout.Width(Screen.width/2 - 250),GUILayout.Height(Screen.height/2 - 240)); 
			
		}
		GUILayout.EndArea ();

		GUILayout.EndVertical ();
		GUILayout.EndArea ();


	}

	public static void OnlyFriendsLeaderBoard(){
	LeaderBoardCallBack.fList.Clear ();
	scoreBoardService.SetQuery (AppConstants.collectionName, null);
	scoreBoardService = App42API.BuildScoreBoardService ();
	if (LeaderBoardCallBack.fbAccessToken.Equals ("") || LeaderBoardCallBack.fbAccessToken == null) {
						errorMessage = true;
						exceptionMessage = "Firstly you Login to facebook.";
				}
	 else 

			scoreBoardService.GetTopNRankersFromFacebook (AppConstants.gameName, LeaderBoardCallBack.fbAccessToken, 10, new FriendsLeaderBoardCallBack ());
	}

	public static void GlobalLeaderBoard(){
		errorMessage = false;
		LeaderBoardCallBack.fList.Clear ();
		FriendsLeaderBoardCallBack.friendList.Clear ();
		LeaderBoardCallBack.fromLeaderBoard = true;
		scoreBoardService = App42API.BuildScoreBoardService ();
		Query q = QueryBuilder.Build ("userId","",Operator.LIKE);
		scoreBoardService.SetQuery (AppConstants.collectionName,q);
		scoreBoardService.GetTopNRankers(AppConstants.gameName, 10, new LeaderBoardCallBack ());
	}

	public static void SaveScore(){
		LeaderBoardCallBack.fromSaveScore = true;
		scoreBoardService = App42API.BuildScoreBoardService ();

		Dictionary<string,object> playerFBProfile = new Dictionary<string, object> ();
		playerFBProfile.Add ("userId",LeaderBoardCallBack.fbUserId);
		playerFBProfile.Add ("name",LeaderBoardCallBack.fbUserName);
		playerFBProfile.Add ("profilePic",LeaderBoardCallBack.fbUserProfilePic);
		scoreBoardService.AddJSONObject (AppConstants.collectionName,playerFBProfile);
		scoreBoardService.SaveUserScore(AppConstants.gameName, LeaderBoardCallBack.fbUserId, MyGame.scoreValue,new LeaderBoardCallBack ());
	}



}
