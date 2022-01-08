using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour
{
    public bool facingRight = true;
    public Vector3 ratPosition;
    Vector3 bulletSide;

    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.PlaySound("Shot");
        if(facingRight){
            bulletSide = new Vector3(6, 0.0f, 0.0f);
            transform.position = ratPosition + new Vector3(1.0f, 0.0f, 0.0f);
        }
        else{
            bulletSide = new Vector3(-6, 0.0f, 0.0f);
            transform.position = ratPosition + new Vector3(-1.0f, 0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + bulletSide * Time.deltaTime * 1.3f;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy (gameObject);
    }
}
