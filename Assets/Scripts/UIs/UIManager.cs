using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject reloadMessageText;

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
}
