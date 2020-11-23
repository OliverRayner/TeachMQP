using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayFire()
    {
        SceneManager.LoadScene("StopThatFire");
    }

    public void PlayFortune()
    {
        SceneManager.LoadScene("FortuneTeller");
    }

    public void PlaySelector()
    {
        SceneManager.LoadScene("Superpower_Selector");
    }

    public void PlayRestaurant()
    {
        SceneManager.LoadScene("Restaurant");
    }

    public void PlayCashier()
    {
        SceneManager.LoadScene("Change");
    }
}
