using UnityEngine;
using System.Collections;

public class LoadingMessage : MonoBehaviour {

	public Color backgroundColor = Color.black;
	public Color textColor = Color.blue;
	public static string message = "Loading...";
	public static string newMessage = "Loading123...";

	public GUISkin MessageStyle;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		message = newMessage;
	}

	void OnGUI() {
		GUI.skin = MessageStyle;
		//cache and update GUI settings
		Color cachedColor = GUI.contentColor;
		GUI.contentColor = textColor;
		//draw label
		float width = 700f;
		float height = 60f;
		float left = Screen.width / 2 - 350f;
		float top = Screen.height / 2 - height;
		Rect rect = new Rect(left, top, width, height);
		GUI.Label (rect, message);
		//GUI.Box(rect,message);
		
		//restore GUI settings
		GUI.contentColor = cachedColor;


		if(LeaderBoardCallBack.fromSaveScore && GUI.Button(new Rect(left, top, width, height+200),"HOME"))
		{	
			LeaderBoardCallBack.fromSaveScore = false;
			Application.LoadLevel("MainScene");
		}
	}

	public static void SetMessage(string messages){
		LoadingMessage.newMessage = messages;
		Application.LoadLevel ("LoadingMScene");
	}
}
