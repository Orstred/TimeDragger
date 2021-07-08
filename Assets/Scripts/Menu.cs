using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public Canvas MenuGraphic;  




    //Mainmenu
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void OpenMenu(GameObject gam)
    {
        gam.SetActive(true);
    }
    public void CloseMenu(GameObject gam)
    {
        gam.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
