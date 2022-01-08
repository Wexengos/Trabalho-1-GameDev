using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nito : MonoBehaviour
{

    private float timer = 0.0f;
    public int life = 0;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (RecalculateValue()){
                bullet = Object.Instantiate(bulletPrefab);
                bullet.GetComponent<ShotBoss>().bossPosition = transform.position;
            }

    }

    public bool RecalculateValue()
    {
        timer += Time.deltaTime;
        if(timer > 3.0f){
            timer = 0;
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Shot"){
            life -= 1;
            if(life == 0){
                Destroy(gameObject);
                AudioSource source = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
                source.Stop();
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
