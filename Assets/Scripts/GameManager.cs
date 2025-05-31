using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject tutorialScreen;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] Player player;

    private bool isPause = false;
    private bool isOpened = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

        if (Input.anyKey && !isOpened)
        {
            CloseTutorial();
            StartCoroutine(Wait());
            player.CanMove = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    public void Pause()
    {
        if (!isPause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        else if (isPause)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseTutorial()
    {
        tutorialScreen.SetActive(false);
        isOpened = true;
    }

    public void UpdateCoinsCounter(int coins = 0)
    {
        coinCounter.text = $"{coins}";
    }
    
}