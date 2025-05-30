using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    public static UI_Health instance;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Awake()
    {
        instance = this;
    }

    public void UpdateHearts(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
        }
    }
}
