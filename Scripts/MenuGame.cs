using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MenuGame : MonoBehaviour
{

    void Start()
    {

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Login();
        //Social.localUser.Authenticate((bool success) =>
        //{
        //    if (success)
        //    {
        //        print("Удачно вошёл");
        //    }
        //    else
        //    {
        //        print("НЕУдачно вошёл");
        //    }
        //});
    }

    public void Login()
    {
        if(Social.localUser.authenticated)
        {
            return;
        }
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                print("Удачно вошёл");
            }
            else
            {
                print("НЕУдачно вошёл");
            }
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
        // Debug.Log("Выход из игры");
        PlayGamesPlatform.Instance.SignOut();
    }
}
