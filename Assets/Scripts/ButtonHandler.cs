using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler 
{
    // Main Menu Button Functions
    public void Btn_PlayGame()
    {
        SceneManager.LoadScene("PlayScreen");
        
        //Add game Manager Script here
    }
    public void Btn_ExitGame()
    {
        Application.Quit();
    }
}
