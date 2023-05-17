using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHome : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Menu");// в кавычках название сцены на которую осуществляется переход
    }

    
}
