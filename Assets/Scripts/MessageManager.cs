using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MessageManager : MonoBehaviour
{
    
    public TextMeshProUGUI TextoPersonaje;

    public Charla[] dialogos;

    public GameObject cortinas;

    public void Start()
    {
        StartCoroutine(Procceed());
    }

    IEnumerator Procceed()
    {
       foreach(Charla dial in dialogos)
        {
            TextoPersonaje.text = dial.mensajes;
            
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(TimerToMenu());
    }

    IEnumerator TimerToMenu()
    {
        cortinas.GetComponent<Animator>().SetTrigger("in");
        //cortinas.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    [System.Serializable]
    public class Charla
    {
        [TextArea]
        public string mensajes;
    }
}
