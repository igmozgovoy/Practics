﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void StartHadler()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }
}
