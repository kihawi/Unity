using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvls : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene 1");// � �������� �������� ����� �� ������� �������������� �������
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("SampleScene 2");// � �������� �������� ����� �� ������� �������������� �������
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("SampleScene 3");// � �������� �������� ����� �� ������� �������������� �������
    }
}
