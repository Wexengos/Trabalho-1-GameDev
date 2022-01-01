using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    public bool facingRight = true;  //O personagem está olhando para a direita?

    public GameObject bulletPrefab;
    public float jumpHeight;
    private bool isGrounded;  //O personagem está num chão?

    public double abyss = -7.5;

    public Animator animator;
    GameObject bullet;

    public int lives = 3;
    Vector3 bulletSide;

    private float timer = 2.0f;

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

    void Start(){
        // SoundManagerScript.PlaySound("Teleporte");
    }

    // Update is called once per frame
    void Update()
    {
        if(RecalculateValue() || !bullet){
            if(Input.GetKeyDown(KeyCode.Z)){
                timer = 0;
                if(bullet){
                    Destroy(bullet);
                }
                bullet = Object.Instantiate(bulletPrefab);
                bullet.AddComponent<Shot>();
                bullet.AddComponent<BoxCollider2D>();
                if(facingRight){
                    bulletSide = new Vector3(6, 0.0f, 0.0f);
                    bullet.transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
                }
                else{
                    bulletSide = new Vector3(-6, 0.0f, 0.0f);
                    bullet.transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
                }
            }
        }
        if(bullet){
            bullet.transform.position = bullet.transform.position + bulletSide * Time.deltaTime * 1.3f;
        }

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
            SoundManagerScript.PlaySound("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight), ForceMode2D.Force);  //checa se o personagem está no chão,
                                                                                                     //se sim, o botão de espaço o faz pular.
        }

        FallDeath();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyJump"){
            ComputeDeath();
        }
        else if(other.gameObject.tag == "Slash"){
            SceneManager.LoadScene(1);
        } 
        else if(other.gameObject.tag == "Portal"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
            ComputeDeath();
        }
    }

    void ComputeDeath()
    {
        transform.position = new Vector3(-5.28f, -2.42f, 0.0f);
        if (lives > 0)
            lives--;
    }

    public bool RecalculateValue()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer > 1.0f){
            return true;
        }
        return false;
    }
}
