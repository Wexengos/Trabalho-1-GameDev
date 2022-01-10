using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    private GameObject player;
    private GameObject text;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GameObject.FindGameObjectWithTag("life");
        text.GetComponent<UnityEngine.UI.Text>().text = (PlayerStats.Lives-1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.transform.position.x  - 7.0f;
        transform.position = temp;
    }
}
