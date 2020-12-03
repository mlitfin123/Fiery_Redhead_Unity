using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Highscores : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful Login");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error Logging In");
        Debug.Log(error.GenerateErrorReport());
    }
}
