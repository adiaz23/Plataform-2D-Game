using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject GameOverMenu;

    private bool isPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
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
            GameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
