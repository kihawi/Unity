using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene 1");// � �������� �������� ����� �� ������� �������������� �������
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void LevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
