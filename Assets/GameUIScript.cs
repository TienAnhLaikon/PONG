using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    public static GameUIScript Instance { get; private set; }
    // Start is called before the first frame update
    [SerializeField] private Text playerWinText;
    public GameObject winScreen;

    public ScoreText player1ScoreText;
    public ScoreText player2ScoreText;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void setPlayerWinText(string text) {
        playerWinText.text = text.ToString();
    }
    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        LogicManagerScript.Instance.audio.PlayWin();
    }
    public void HideWinScreen()
    {
        winScreen.SetActive(false);
    }
}
