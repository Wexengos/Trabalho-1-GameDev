using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEgg : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public bool facingRight = true;

    public SpriteRenderer sprite;

    private float xScale;
    public int life;

    public Animator animator;

    public float distance = 5;
    float revert = -5;

    private float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        xScale = -1;
    }

    // Update is called once per frame
    void Update()
    {
        RecalculateValue();

        Vector3 side = new Vector3(xScale, 0.0f, 0.0f);
        float yScale = transform.localScale.y;
        transform.position = transform.position + side * Time.deltaTime;
        transform.localScale = new Vector2(revert, yScale); 
    }

    public void RecalculateValue()
    {
        timer += Time.deltaTime;
        if(timer > 3.0f){
            xScale *= -1;
            timer = 0;
            revert *= -1;
        }
    }

    float isFacingRight(float xScale)
    {                         //Verifica: se o personagem estiver se movendo para um lado e
        if (Input.GetAxis("Horizontal") < 0 && facingRight)
        {    //não estiver olhando para este, o lado para o qual ele está
            facingRight = false;                                //virado se altera. 
            return -xScale;
        }
        else if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            facingRight = true;
            return -xScale;
        }
        else
            return xScale;
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
