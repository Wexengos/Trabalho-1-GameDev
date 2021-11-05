using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    bool facingRight = true;
    public Animator animator;
    
    float isFacingRight(float xScale) {                         //Verifica: se o personagem estiver se movendo para um lado e
        if(Input.GetAxis("Horizontal") < 0 && facingRight) {    //não estiver olhando para este, o lado para o qual ele está
            facingRight = false;                                //virado se altera. 
            return -xScale;
        }
        else if(Input.GetAxis("Horizontal") > 0 && !facingRight) {
            facingRight = true;
            return -xScale;
        }
        else
            return xScale;
    }
    // Update is called once per frame
    void Update()
    {
    
        float xScale = transform.localScale.x;
        float yScale = transform.localScale.y;

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f); //Vetor para o movimento. Altera apenas eixo X.
        Vector2 side = new Vector2(isFacingRight(xScale), 0.0f);

        transform.position = transform.position + horizontal * Time.deltaTime * 5;            //"Time.deltaTime" deixa o movimento "mais liso",
                                                                                              //uma vez que o script roda a cada Update().
        transform.localScale = new Vector2(side.x, yScale);  //espelhamento do personagem no movimento
    }
}
