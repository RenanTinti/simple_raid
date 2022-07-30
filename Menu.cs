using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource introTheme;
    public void PlayGame(){
        
        SceneManager.LoadScene("SC_1");
    }

    public void ExitGame(){
        Application.Quit();
    }
}
