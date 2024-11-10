using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour 
{
    public GameManager gM;
    // Main Menu Button Functions
    public void Btn_PlayGame()
    {
        SceneManager.LoadScene("PlayScreen");        
        gM.Game_State = 1;
    }
    public void Btn_ExitGame()
    {
        Application.Quit();
    }
}
