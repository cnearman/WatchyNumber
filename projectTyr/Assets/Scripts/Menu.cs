using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) => { Debug.Log("successfully authenticated"); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGame()
    {
        SceneManager.LoadScene("TheGame");
    }

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
        //PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIjdu1vMYaEAIQAA");
    }
}
