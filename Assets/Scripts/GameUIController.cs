using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Home ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
