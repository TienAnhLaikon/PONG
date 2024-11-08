using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text playerScoreText;
    public Animator animator;
    public void Highlight()
    {
        animator.SetTrigger("highlight");
    }
    public void SetScore(int value)
    {
        Highlight();
        playerScoreText.text = value.ToString();

    }

}
