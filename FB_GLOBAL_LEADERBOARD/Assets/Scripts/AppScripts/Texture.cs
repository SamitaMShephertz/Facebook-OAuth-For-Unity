using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp;

public class Texture : MonoBehaviour {

	private static Texture restCon = null;
	private static string lockString = "lock";
	private static bool applicationIsQuitting = false;
	public static  Texture GetInstance ()
	{
		if (applicationIsQuitting) {
			App42Log.Console ("[Singleton] Instance already destroyed on application quit." +
			                  " Won't create again - returning null.");
			return null;
		}
		lock (lockString) {
			if (restCon == null) {
				App42Log.Console (" GetInstance Null ");
				GameObject gameObj = new GameObject ("Texture");
				restCon = gameObj.AddComponent<Texture> ();
				DontDestroyOnLoad (gameObj);
				return restCon;
			} else {
				App42Log.Console (" GetInstance Not Null ");
				return restCon;
			}
		}
		
	}
	
	public void ExecuteShow (string userId, string pp)
	{
		Debug.Log("Executing Show..");
		StartCoroutine (ExecuteLeaderBoard (userId,pp));
	}
	
	IEnumerator ExecuteLeaderBoard(string userId, string pp)
	{
		Debug.Log("Executing LeaderBoard...");
		IEnumerator e = ExecuteShowAll (userId,pp);
		while (e.MoveNext())
		{
			yield return e.Current;
		}
	}
	
	
	IEnumerator ExecuteShowAll (string userId, string pp)
	{
		Debug.Log("Executing ShowAll..");
		WWW www = new WWW (pp);
		
		while (!www.isDone) 
		{
			Debug.Log("Working...");
			yield return null;  
		}
		if (www.isDone)
		{
			Debug.Log("Done...");
			if(!FBLeaderBoard.dist.ContainsKey(userId))
			{
				Debug.Log("Finalizing...");
				FBLeaderBoard.dist.Add(userId,www.texture);
			}
		}
	}
}
