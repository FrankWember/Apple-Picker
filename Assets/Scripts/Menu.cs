using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public void OnPlayButton()
   {
    SceneManager.LoadScene("_Scene_0");
   }
   public void OnQuitButton()
{
    Application.Quit();
}
    public void OnAboutGameButton()
    {
        SceneManager.LoadScene("AboutGame");
    }
    public void onMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
