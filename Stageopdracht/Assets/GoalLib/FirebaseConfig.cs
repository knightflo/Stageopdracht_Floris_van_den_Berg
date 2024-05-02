using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "FirebaseConfig", menuName = "ScriptableObjects/FirebaseConfig", order = 1)]
public class FirebaseConfig : ScriptableObject
{
    private static FirebaseConfig _Instance;
    public static FirebaseConfig Instance
	{
		get
		{
            if (_Instance == null)
            {
                _Instance = Resources.LoadAll<FirebaseConfig>("")[0];
            }
            return _Instance;
        }
	}

  //  [InfoBox("Make sure this is placed in the resources folder", InfoMessageType.Info)]

    public string ProjectName = "AllAboardNow";
    [Header("ProjectSettings")]

    [SerializeField]  private string APIKEY = "";
    [SerializeField]  private string serverBaseURL = @"";
    [SerializeField]  private string Localserver_BaseURL = @"http://localhost:5001/";

    [Header("Authentication")]

    [SerializeField]  private string SignInUserUrl = @"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=";
    [SerializeField]  private string CreateNewUserUrl = @"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=";
    [SerializeField]  private string Localserver_SignInUserUrl = @"http://localhost:9099/identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=";
    [SerializeField]  private string Localserver_CreateNewUserUrl = @"http://localhost:9099/identitytoolkit.googleapis.com/v1/accounts:signUp?key=";

    [Header("Simulator")]
    [SerializeField]  private bool UseLocalFirebaseSimulator = false;

    public string SignInURL
    {
        get
        {

            if (!UseLocalFirebaseSimulator)
                return SignInUserUrl + APIKEY;
            else return Localserver_SignInUserUrl + APIKEY;
        }
    }
    public string CreateAccURL
    {
        get
        {
            if (!UseLocalFirebaseSimulator)
                return CreateNewUserUrl + APIKEY;
            else return Localserver_CreateNewUserUrl + APIKEY;
        }
    }

    public string DatabaseURL
    {
        get
        {
            if (!UseLocalFirebaseSimulator)
                return serverBaseURL;
            else return Localserver_BaseURL;

        }
    }

    //http://localhost:[PORT]/identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=[API-KEY]
}
