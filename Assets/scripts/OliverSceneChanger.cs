using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OliverSceneChanger : MonoBehaviour
{
    public void Scenechange(string stringname)
    {
        SceneManager.LoadScene(stringname);
    }
}
