using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public class ShotBoss : MonoBehaviour
{

    Vector3 bulletSide;
    int num;
    public Vector3 bossPosition;
    // Start is called before the first frame update
    void Start()
    {
        var rand = new System.Random();
        num = rand.Next(0, 10);
        SoundManagerScript.PlaySound("Slash");
        bulletSide = new Vector3(-13, 0.0f, 0.0f);
        transform.position = bossPosition + new Vector3(-2.0f, -1.0f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        if(num %2==0){
            transform.position = transform.position + bulletSide * Time.deltaTime;
        }
        else{
            transform.position += new Vector3 (-0.0181f, Mathf.Sin (1 * x) * 0.011f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy (gameObject);
    }
}
