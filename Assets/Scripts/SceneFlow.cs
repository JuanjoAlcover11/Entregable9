using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{//Haemos que se cargue la escena options
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
