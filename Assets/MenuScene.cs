using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Text volumeValueText;

    public void PlayButton()
    {
        SceneManager.LoadScene(1); // 0 is main menu and 1 is the game
    }
    public void ExitButton()
    {

    }
    public void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        volumeValueText.text = $"{Mathf.RoundToInt(value* 100)}%";
    }




}
