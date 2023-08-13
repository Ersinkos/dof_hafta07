using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject inputField;
    public GameObject slider;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayerNameInput()
    {
        PlayerPrefs.SetString("PlayerName", inputField.GetComponent<TMP_InputField>().text);
        print("Oyuncu Adý : " + PlayerPrefs.GetString("PlayerName"));
        PlayerPrefs.Save();
    }
    public void GetSpeedFromSlider()
    {
        PlayerPrefs.SetFloat("PlayerSpeed", slider.GetComponent<Slider>().value);
        print("Oyuncu Hýzý : " + PlayerPrefs.GetFloat("PlayerSpeed"));
        PlayerPrefs.Save();

    }
}
