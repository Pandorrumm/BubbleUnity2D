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
       Login();
       
    }

    public void Login()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        if (Social.localUser.authenticated)
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

    public static void ShowLeaderboards()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_flight_masters);
        //Social.ShowLeaderboardUI();
    }

    public static void ReportScore(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_flight_masters, (bool success) =>
        {
            if (success)
            {
                print("Удачно добавляем в таблицу лидеров");
            }
            else
            {
                print("НЕУдачно добавляем в таблицу лидеров");
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
