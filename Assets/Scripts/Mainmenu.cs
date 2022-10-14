using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("0");
    }

    public void Levels()
    {
        SceneManager.LoadScene("LevelControl");
    }
}
