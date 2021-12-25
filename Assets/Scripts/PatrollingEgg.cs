using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEgg : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public bool facingRight = true;

    private float xScale;
    public int life = 0;

    public Animator animator;

    public float distance = 5;

    private int lastRecalculation = 400;


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
        transform.position = transform.position + side * Time.deltaTime;
    }

    public void RecalculateValue()
    {
        if (Time.frameCount % lastRecalculation == 0)
            xScale *= -1;
    }


}
