using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public static LogicManagerScript Instance { get; private set; }
    public int player1Score = 0;
    public int player2Score = 0;
    public int maxScore = 4;
    public Shake screenShake;
    public AudioManagerScript audio;
    void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject); // Giữ đối tượng qua các scene
        //}
        //else
        //{
        //    Destroy(gameObject); // Đảm bảo chỉ có một instance
        //}
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
 player1Score = 0;
 player2Score = 0;
        GameUIScript.Instance.player1ScoreText.SetScore(player1Score);
        GameUIScript.Instance.player2ScoreText.SetScore(player2Score);
        GameUIScript.Instance.HideWinScreen();

        // Reset vị trí quả bóng và các player
        BallScript ball = FindObjectOfType<BallScript>();
        if (ball != null)
        {
            ball.ResetBall();
        }

        Player1Script player1 = FindObjectOfType<Player1Script>();
        if (player1 != null)
        {
            player1.ResetPosition();
        }

        Player2Script player2 = FindObjectOfType<Player2Script>();
        if (player2 != null)
        {
            player2.ResetPosition();
        }
    }
    [ContextMenu("Increase Player 1 Score")]
    public void IncreaseScorePlayer1()
    {
        player1Score++;
        LogicManagerScript.Instance.audio.PlayScore();
        screenShake.StartShake(0.33f,0.1f);
        GameUIScript.Instance.player1ScoreText.SetScore(player1Score);
        if (player1Score == maxScore) {
            GameUIScript.Instance.setPlayerWinText("PLAYER 1 WINS!");
            GameUIScript.Instance.ShowWinScreen();
            // Reset vị trí quả bóng và các player
            BallScript ball = FindObjectOfType<BallScript>();
            if (ball != null)
            {
                ball.stopBall();
            }
        }
        
    }
    public void IncreaseScorePlayer2()
    {
        player2Score++;
        LogicManagerScript.Instance.audio.PlayScore();
        GameUIScript.Instance.player2ScoreText.SetScore(player2Score);
        screenShake.StartShake(0.33f, 0.1f);

        if (player2Score == maxScore)
        {
            GameUIScript.Instance.setPlayerWinText("PLAYER 2 WINS!");
            GameUIScript.Instance.ShowWinScreen();
            // Reset vị trí quả bóng và các player
            BallScript ball = FindObjectOfType<BallScript>();
            if (ball != null)
            {
                ball.stopBall();
            }
        }
    }


}
