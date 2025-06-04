using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("중앙 상단")]
    public TMP_Text playTimeText;
    public TMP_Text killCountText;

    [Header("중앙 하단")]
    public GameObject reloadMessageText;

    [Header("좌측 상단")]
    public Image[] heartImages;

    [Header("좌측 하단")]
    public Image itemSlot;

    [Header("우측 상단")]
    public RawImage minimap;

    [Header("우측 하단")]
    public Image weaponIcon;
    public TMP_Text ammoText;


    private void Awake()
    {
        Instance = this;
        reloadMessageText.SetActive(false);
    }

    public void ShowReloadMessage()
    {
        reloadMessageText.SetActive(true);
        CancelInvoke(nameof(HideReloadMessage));
        Invoke(nameof(HideReloadMessage), 2f);
    }

    private void HideReloadMessage()
    {
        reloadMessageText.SetActive(false);
    }

    //중앙 상단 카운트
    public void UpdateKillCount(int kills, int bossKills)
    {
        killCountText.text = $"처치: {kills} / 보스: {bossKills}";
    }

    public void UpdatePlayTime(float timeSec)
    {
        int min = Mathf.FloorToInt(timeSec / 60f);
        int sec = Mathf.FloorToInt(timeSec % 60f);
        playTimeText.text = $"{min:D2}:{sec:D2}";
    }

    // 좌측 상단 체력바
    public void UpdateHealth(int currentHp)
    {
        for (int i = 0; i < heartImages.Length; i++)
            heartImages[i].enabled = i < currentHp;
    }

    //좌측 하단 아이템칸
    public void SetItem(Sprite icon)
    {
        itemSlot.sprite = icon;
        itemSlot.enabled = true;
    }

    public void ClearItem()
    {
        itemSlot.enabled = false;
    }

    // 우측 하단 잔탄수
    public void UpdateWeapon(Sprite icon, int current, int max)
    {
        weaponIcon.sprite = icon;
        ammoText.text = $"{current} / {max}";
    }

}
