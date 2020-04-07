using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private GameObject pauseImage;
    [SerializeField] private GameObject settingsImage;
	[SerializeField] CanvasGroup CanvasGroup;
    [SerializeField] private AudioClip pauseIN;
    [SerializeField] private AudioClip pauseOut;
    private bool paused;
    private AudioSource audioSource;


	void Start()
	{
		pauseCanvas.enabled =false;
		//CanvasGroup.interactable = false;
        audioSource = GetComponent<AudioSource>();
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
		//CanvasGroup.interactable = pauseCanvas.enabled;
        AudioClip cosito = Time.timeScale == 1 ? pauseOut : pauseIN;
        audioSource.PlayOneShot(cosito);
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
        //settingsImage.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    
}
