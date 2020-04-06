using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private GameObject pauseImage;
    [SerializeField] private GameObject settingsImage;
	[SerializeField] CanvasGroup CanvasGroup;
    private bool paused;

	void Start()
	{
		pauseCanvas.enabled =false;
		CanvasGroup.interactable = false;
	}

	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            Pause();
        }
    }

    public void Pause()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;
		CanvasGroup.interactable = pauseCanvas.enabled;

		Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    public void LoadSettings()
    {
        pauseImage.SetActive(false);
        settingsImage.SetActive(true);
    }

    public void LoadPause()
    {
        pauseImage.SetActive(true);
        settingsImage.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    
}
