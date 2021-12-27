using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuObject : MonoBehaviour
{
    public void Start(){

    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Y)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
