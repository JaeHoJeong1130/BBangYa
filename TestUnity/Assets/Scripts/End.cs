using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    public void RetryClick()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitClick()
    {
        Application.Quit();
    }
}
