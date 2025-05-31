using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] GameObject signText;
    [SerializeField] Player player;
    
    private bool isPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
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

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");  
    }

    public void UpdateCoinsCounter(int coins = 0)
    {
        coinCounter.text = $"{coins}";
    }

    public void ShowText()
    {
        signText.SetActive(true);
    }

    public void HideText()
    {
        signText.SetActive(false);
    }

    public void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

}