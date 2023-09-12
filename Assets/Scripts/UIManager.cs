using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private bool isGameOver = false;

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
        this.isGameOver = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && this.isGameOver)
        {
            this.isGameOver = false;
            SceneManager.LoadScene("Game");
        }

        // handle ESC to open menu
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
