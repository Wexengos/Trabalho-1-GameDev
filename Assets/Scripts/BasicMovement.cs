using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public bool facingRight = true;  //O personagem está olhando para a direita?

    public float jumpHeight;
    private bool isGrounded;  //O personagem está num chão?

    public double abyss = -7.5;

    public Animator animator;

    public int lives = 3;

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight), ForceMode2D.Force);  //checa se o personagem está no chão,
                                                                                                     //se sim, o botão de espaço o faz pular.
        }

        FallDeath();
    }
    //Há uma caixa de colisão com um 'Is Trigger' que envolve o jogador, que é ativado toda vez que este colide.
    void OnTriggerEnter2D()
    {
        isGrounded = true;   //Se o jogador toca o chão, ele está no chão.
    }
    void OnTriggerStay2D()
    {
        isGrounded = true;   //Se ele permanece no chão, obviamente está no chão.
    }
    void OnTriggerExit2D()
    {
        isGrounded = false;  //Se ele deixa o chão, não pode pular, pois já está caindo/pulando.
    }

    void FallDeath()
    {
        if (transform.position.y <= abyss)
        {
            Debug.Log("Foi Brabo Pica");
            ComputeDeath();
        }
    }

    void ComputeDeath()
    {
        transform.position = new Vector3(-5.28f, -2.42f, 0.0f);
        if (lives > 0)
            lives--;
    }
}
