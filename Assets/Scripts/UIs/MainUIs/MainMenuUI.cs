using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject optionsPanel;
    public GameObject weaponsPanel;

    [Header("Audio")]
    public Slider volumeSlider;

    void Start()
    {
        // ÃÊ±â ÆÐ³Î ¼û±è
        optionsPanel.SetActive(false);
        weaponsPanel.SetActive(false);

        // º¼·ý ÃÊ±âÈ­
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void OnOptions()
    {
        optionsPanel.SetActive(true);
        weaponsPanel.SetActive(false);
    }

    public void OnWeapons()
    {
        weaponsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        optionsPanel.SetActive(false);
        weaponsPanel.SetActive(false);
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}
