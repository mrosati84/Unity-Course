using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Image livesSprite;

    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private Sprite[] livesSprites = new Sprite[4];

    public void SetScoreText(int value)
    {
        this.scoreText.text = "Score: " + value.ToString();
    }

    public void SetLives(int lives)
    {
        this.livesSprite.sprite = this.livesSprites[lives];
    }

    public void GameOver()
    {
        this.gameOverText.gameObject.SetActive(true);
    }
}
