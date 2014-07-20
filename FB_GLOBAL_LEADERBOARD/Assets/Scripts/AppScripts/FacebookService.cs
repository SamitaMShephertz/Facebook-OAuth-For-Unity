using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp.social;
using com.shephertz.app42.paas.sdk.csharp;

public class FacebookService{

	static SocialService socialService = null;

	public static string fbAccessToken = ""; 

	public static void ConnectWithFacebook(){
		socialService = App42API.BuildSocialService ();
		// Making facebook Permissions Array.
		string[] perms = new string[10];
		perms [0] = FBPerms.email;		
		perms [1] = FBPerms.user_friends;
		socialService.DoFBOAuthAndGetToken (AppConstants.FB_APP_ID, perms, false, new LeaderBoardCallBack ());
	}
}
