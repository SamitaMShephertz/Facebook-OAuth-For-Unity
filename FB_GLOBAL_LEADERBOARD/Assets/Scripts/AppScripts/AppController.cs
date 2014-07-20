using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.social;
using System.Net;

public class AppController : MonoBehaviour {
	public bool isConnected = false;
	#if UNITY_EDITOR
	public static bool Validator (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
	{return true;}
	#endif
	void Start ()
	{
		#if UNITY_EDITOR
		ServicePointManager.ServerCertificateValidationCallback = Validator;
		#endif
		App42API.Initialize (AppConstants.API_KEY,AppConstants.SECRET_KEY);
		App42API.EnableCrashEventHandler (false);
		App42Log.SetDebug (true);
		App42API.SetDbName (AppConstants.DB_NAME);
	}
	
	// Update is called once per frame
	void Update () {
		if (!LeaderBoardCallBack.fbAccessToken.Equals ("") && LeaderBoardCallBack.isConnected) {
			Debug.Log ("====================ACCESS TOKEN RECIEVED========================");
			LeaderBoardCallBack.isConnected = false;
			AppConstants.GetSocialService ().GetFacebookProfile (LeaderBoardCallBack.fbAccessToken, new LeaderBoardCallBack ());
		}
	}
}
