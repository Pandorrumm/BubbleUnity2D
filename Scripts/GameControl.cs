using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GameControl : MonoBehaviour
{
    public static GameControl Instance; //экземпляр

    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score = 0;
    public int MaxScore;
    public Text scoreText;
    public Text MaxScoreText;
    
   // public GameObject gameOverText;
    public GameObject gameOverPanel;
    public GameObject readyPanel;

    public AdMobInterstitial ad;
    public static int deadCounter = 0; //счётчик смертей

    private static PlayerData playerData;

    private ParallaxBackGround parallaxBackGround;

    private PauseButton pause;
    public GameObject pauseButton;

    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private AudioSource[] myAudio;

    private const string leaderboard = "CgkIlf6A1qEQEAIQAQ";  // из Play Console

    void Start()
    {
        pause = FindObjectOfType<PauseButton>();
        parallaxBackGround = FindObjectOfType<ParallaxBackGround>();
        toggle = FindObjectOfType<Toggle>();

        MaxScore = PlayerPrefs.GetInt("MaxScore");
        readyPanel.SetActive(true);
        pause.pauzePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;

       
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesPlatform.InitializeInstance(config);
        //PlayGamesPlatform.Activate();  //выбор аккаунта в гугл плей
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

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else if(Instance != null)
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = false;
           // myAudio[0].mute = true;
           // myAudio[1].mute = true;
            PlayerPrefs.Save();
        }
        
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio[0].mute = false;
                myAudio[1].mute = false;
                //myAudio[0].enabled = false;
                //myAudio[1].enabled = false;
                toggle.isOn = false;
            }
            else
            {
                myAudio[0].mute = true;
                myAudio[1].mute = true;
                //myAudio[0].enabled = true;
                //myAudio[1].enabled = true; 
                toggle.isOn = true;
            }
        }
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            //myAudio[0].enabled = true;
            //myAudio[1].enabled = true;
            myAudio[0].mute = true;
            myAudio[1].mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            myAudio[0].mute = false;
            myAudio[1].mute = false;
            //myAudio[0].enabled = false;
            //myAudio[1].enabled = false;
        }
        PlayerPrefs.Save();
    }

    void Update()
    {

        if (MaxScore < score)
        {
            MaxScore = score;
            PlayerPrefs.SetInt("MaxScore", MaxScore);

            ReportScore(MaxScore);
        }

        if(MaxScore > score)
        {
            MaxScoreText.text = "Рекорд: " + MaxScore;
        }
    }

    public void LeaderboardButton()
    {
        Social.ShowLeaderboardUI();
    }

    public void ReportScore(int score)
    {

        Social.ReportScore(score, /*GPGSIds.leaderboard_flight_masters*/ leaderboard, (bool success) =>
        {

            if (success)
            {
                print("Удачно добавляем в таблицу лидеров");
            }

        });
    }

    public void Score()
    {
        if (isGameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Очки: " + score;
    }

    public void Die()
    {
        isGameOver = true;      
        Invoke("GameOverTextActiv", 1f);
        pauseButton.SetActive(false);
    }

    void GameOverTextActiv()
    {
        //gameOverText.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        
        //PlayerPrefs.SetInt("deadCounter", deadCounter);
        deadCounter++;
        Debug.Log(deadCounter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
       
    }

    public void ReadyPanel()
    {
        pause.pauzePanel.SetActive(false);
        readyPanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.PlaySound("CreateBooble");
        pauseButton.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuGame");
        //Application.Quit();
        // Debug.Log("Выход из игры");
       // PlayGamesPlatform.Instance.SignOut();

    }

    public void AdmobShow()
    {
        if (deadCounter % 3 == 0)
        {
            ad.ShowAds();
            Debug.Log(deadCounter);
            Debug.Log("показ баннера");
        }
    }

    public void SavePlayer()
    {
        SaveScript.SavePlayer(this);
        Debug.Log("Сохранили");

    }

    public void Load()
    {
        
        // SceneManager.LoadScene("ChoiceLevels");
       // PlayerData data = SaveScript.LoadPlayer();
       // GameControl.deadCounter = data.deadCounter;
        Debug.Log("Загрузили");
    }

   

}
