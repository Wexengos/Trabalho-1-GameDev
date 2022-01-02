using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShotBoss : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.PlaySound("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy (gameObject);
    }
}
