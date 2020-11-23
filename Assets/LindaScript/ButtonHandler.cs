using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    /*   public void SetText(string text)
       {
           Text txt = transform.Find("Text").GetComponent<Text>();
           txt.text = text;

           Image pk = GameObject.Find("Fire1").GetComponent<Image>();
           pk.enabled = false;

       }*/
}
