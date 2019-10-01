using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class GPS : MonoBehaviour
{
    private const string leaderboard = "CgkIlf6A1qEQEAIQAQ";  // из Play Console
    private GameControl gamecontrol;


    void Start()
    {
      
        gamecontrol = FindObjectOfType<GameControl>();

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Login();    
    }

    public void ShowLeaderboards()
    {
        
        Social.ShowLeaderboardUI();
    }

    public void Login()
    {
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


    public void ReportScore()
    {
        Social.ReportScore(gamecontrol.MaxScore, leaderboard, (bool success) =>
        {
            if (success)
            {
                print("Удачно добавляем в таблицу лидеров");
            }

        });
    }
}
