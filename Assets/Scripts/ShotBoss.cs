using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShotBoss : MonoBehaviour
{

    Vector3 bulletSide;
    public Vector3 bossPosition;
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.PlaySound("Slash");
        bulletSide = new Vector3(-12, 0.0f, 0.0f);
        transform.position = bossPosition + new Vector3(-2.0f, -1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + bulletSide * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy (gameObject);
    }
}
