using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nito : MonoBehaviour
{

    private float timer = 0.0f;
    public int life = 0;
    public GameObject bulletPrefab;
    public GameObject bullet;

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
}
