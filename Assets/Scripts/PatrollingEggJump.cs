using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEggJump : MonoBehaviour
{
    public float jumpHeight;
    public int life = 0;
    private float xScale;
    private float timer = 0.0f;
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
}
