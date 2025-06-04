using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Game : MonoBehaviour
{
   public static UI_Game instance;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI bossKillText;
    public TextMeshProUGUI healItemText;
    public TextMeshProUGUI bossDieText;

    float playTime = 0f;
    int bossKill = 0;

    void Awake() => instance = this;

    void Update()
    {
        playTime += Time.deltaTime;
        timeText.text = $"Time: {GetPlayTime()}";
    }

    public string GetPlayTime()
    {
        int min = Mathf.FloorToInt(playTime / 60);
        int sec = Mathf.FloorToInt(playTime % 60);
        return $"{min:D2}:{sec:D2}";
    }

    public void UpdateKillCount(int kill)
    {
        killText.text = $"Kill: {kill} / 100";
    }

    public void BossKilled()
    {
        bossKill++;
        bossKillText.text = $"Boss: {bossKill}";
    }

    public void ShowMessage(string msg, float duration = 2f)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine(msg, duration));
    }

    IEnumerator ShowMessageRoutine(string msg, float duration)
    {
        healItemText.text = msg;
        healItemText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        healItemText.gameObject.SetActive(false);
    }
    public void BossDie()
    {       
        ShowMessage("보스를 처치했습니다!", 3f);        
    }
}
