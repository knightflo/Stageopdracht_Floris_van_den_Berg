using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
public class ServerManager : MonoBehaviour
{
    private static ServerManager _Instance;

    public static ServerManager Instance
	{

		get
		{
            if(_Instance == null)
			{
                var go = new GameObject();
                _Instance = go.AddComponent<ServerManager>();
                DontDestroyOnLoad(go);
			}

            return _Instance;
		}

	}
	public struct NetworkResponse
	{
		public bool isSuccess;
		public string message;

	}
	internal struct CreateAccountDesc
	{
		public string email;
		public string password;
		public string displayName;
		public bool returnSecureToken;
	}
	public void CreateAccount(string DisplayName, string Pass, string Email, UnityAction<NetworkResponse> callback)
	{
		StartCoroutine(CreateAccRoutine(DisplayName,Pass,Email,callback));
	}
	IEnumerator CreateAccRoutine(string DisplayName, string Pass, string Email, UnityAction<NetworkResponse> callback)
	{
		var url = FirebaseConfig.Instance.CreateAccURL;

		var data = new CreateAccountDesc { email = Email, password = Pass, displayName = DisplayName, returnSecureToken = true };


		byte[] bytePostData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
		UnityWebRequest request = UnityWebRequest.Put(url, bytePostData); //use PUT method to send simple stream of bytes
		request.method = "POST"; //hack to send POST to server instead of PUT
		request.SetRequestHeader("Content-Type", "application/json");

		request.SendWebRequest();

		while (!request.isDone) yield return null;

		Debug.Log(request.downloadHandler.text);

		NetworkResponse resp = new NetworkResponse();
		resp.isSuccess = request.result == UnityWebRequest.Result.Success;
		resp.message = request.downloadHandler.text;
		callback?.Invoke(resp);
	}

	public void Authenticate(string Pass, string Email, UnityAction<NetworkResponse> callback)
	{
		StartCoroutine(AuthenticateRoutine( Pass, Email, callback));
	}
	IEnumerator AuthenticateRoutine( string Pass, string Email, UnityAction<NetworkResponse> callback)
	{
		var url = FirebaseConfig.Instance.SignInURL;

		var data = new CreateAccountDesc { email = Email, password = Pass, returnSecureToken = true };


		byte[] bytePostData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
		UnityWebRequest request = UnityWebRequest.Put(url, bytePostData); //use PUT method to send simple stream of bytes
		request.method = "POST"; //hack to send POST to server instead of PUT
		request.SetRequestHeader("Content-Type", "application/json");

		request.SendWebRequest();

		while (!request.isDone) yield return null;

		Debug.Log(request.downloadHandler.text);

		NetworkResponse resp = new NetworkResponse();
		resp.isSuccess = request.result == UnityWebRequest.Result.Success;
		resp.message = request.downloadHandler.text;
		callback?.Invoke(resp);
	}
	public void PostScore(string IDToken, int Score, string GameName, UnityAction<NetworkResponse> callback)
	{
		StartCoroutine(PostScoreRoutine(IDToken, Score, GameName, callback));
	}

	public struct PostScoreDesc
	{
		public string gamename;
		public string uuid;
		public int score;
	}
	IEnumerator PostScoreRoutine(string IDToken, int Score,string GameName, UnityAction<NetworkResponse> callback)
	{
		var url = FirebaseConfig.Instance.DatabaseURL + "/postscore";

		var data = new PostScoreDesc { uuid = IDToken, score = Score, gamename =  GameName };


		byte[] bytePostData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
		UnityWebRequest request = UnityWebRequest.Put(url, bytePostData); //use PUT method to send simple stream of bytes
		request.method = "POST"; //hack to send POST to server instead of PUT
		request.SetRequestHeader("Content-Type", "application/json");

		request.SendWebRequest();

		while (!request.isDone) yield return null;

		Debug.Log(request.downloadHandler.text);

		NetworkResponse resp = new NetworkResponse();
		resp.isSuccess = request.result == UnityWebRequest.Result.Success;
		resp.message = request.downloadHandler.text;
		callback?.Invoke(resp);
	}


}
