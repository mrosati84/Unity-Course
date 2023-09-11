using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Image livesSprite;

    [SerializeField]
    private Sprite[] livesSprites = new Sprite[4];

    public void setScoreText(int value)
    {
        this.scoreText.text = "Score: " + value.ToString();
    }

    public void setLives(int lives)
    {
        this.livesSprite.sprite = this.livesSprites[lives];
    }
}
