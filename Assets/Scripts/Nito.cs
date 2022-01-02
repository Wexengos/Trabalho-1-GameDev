using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nito : MonoBehaviour
{

    private float timer = 0.0f;
    public int life = 0;
    public GameObject bulletPrefab;
    public GameObject PortalPrefab;
    public GameObject bullet;
    Vector3 bulletSide;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (RecalculateValue()){
                bullet = Object.Instantiate(bulletPrefab);
                bulletSide = new Vector3(-12, 0.0f, 0.0f);
                bullet.transform.position = transform.position + new Vector3(-2.0f, -1.0f, 0.0f);
            }
            if(bullet){
                bullet.transform.position = bullet.transform.position + bulletSide * Time.deltaTime;
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
