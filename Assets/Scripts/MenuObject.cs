using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuObject : MonoBehaviour
{
    public void Blau(){
        // Console.WriteLine("teste");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
