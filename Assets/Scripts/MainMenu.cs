﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
