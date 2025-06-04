using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    public static UI_Health instance;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Awake() => instance = this;

    public void UpdateHearts(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                hearts[i].enabled = true;
            }
        }
    }
}
