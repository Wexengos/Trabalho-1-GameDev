using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEggJump : MonoBehaviour
{
    public float jumpHeight;
    public int life = 0;
    private float xScale;
    private float timer = 0.0f;

    public SpriteRenderer sprite;

    void Start()
    {
        xScale = 1;
    }

    void Update()
    {
        RecalculateValue();
        Vector3 side = new Vector3(0.0f, xScale, 0.0f);
        transform.position = transform.position + side * Time.deltaTime * 3;
    }

    public void RecalculateValue()
    {
        timer += Time.deltaTime;
        if(timer > 1.0f){
            xScale *= -1;
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Shot"){
            life -= 1;
            if(life == 0){
                Destroy(gameObject);
            }
            StartCoroutine(flashRed());
        }
    }

    public IEnumerator flashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
