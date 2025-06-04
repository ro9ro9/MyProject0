using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Result : MonoBehaviour
{
    public static UI_Result instance;
    public GameObject resultPanel;
    public Text resultText;
    public Text continueText;

    void Awake() => instance = this;

    public void ShowResult()
    {
        resultPanel.SetActive(true);
        resultText.text = $"플레이 시간: {UI_Game.instance.GetPlayTime()}\n" +
                          $"일반 적 처치: {KillCounter.instance.enemyKillCount}\n" +
                          $"보스 처치: 1";

        StartCoroutine(ShowContinueText());
    }

    IEnumerator ShowContinueText()
    {
        yield return new WaitForSeconds(3f);
        continueText.text = "아무 키나 누르면 다음 맵으로 이동합니다.";

        yield return new WaitUntil(() => Input.anyKeyDown);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
