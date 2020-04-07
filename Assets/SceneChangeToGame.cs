using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneChangeToGame : MonoBehaviour
{
    public string sceneName;
    public GameObject cortinas;
    public void ChangeToGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator TimerToMenu()
    {
        cortinas.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}
