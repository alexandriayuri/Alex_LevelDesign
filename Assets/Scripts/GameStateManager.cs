using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    private CanvasGroup pauseMenuCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseMenuCanvasGroup = pauseMenu.GetComponent<CanvasGroup>();

        if (pauseMenuCanvasGroup == null)
        {
            pauseMenuCanvasGroup = pauseMenu.AddComponent<CanvasGroup>();
            Debug.Log("CanvasGroup was added to pauseMenu.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseMenuCanvasGroup.blocksRaycasts = true;
        Debug.Log("Blocking raycasts.");
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseMenuCanvasGroup.blocksRaycasts = false;
        Debug.Log("Activating raycasts.");
        Time.timeScale = 1f;
        isPaused = false;
    }
}
