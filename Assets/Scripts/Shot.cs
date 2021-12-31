using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour
{

    GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.PlaySound("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy (gameObject);
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<PatrollingEgg>().life -= 1;
            if(other.gameObject.GetComponent<PatrollingEgg>().life == -3){
                
                Destroy(other.gameObject);
            }
        }
        else if(other.gameObject.tag == "Boss"){
            other.gameObject.GetComponent<Nito>().life -= 1;
            if(other.gameObject.GetComponent<Nito>().life == 0){
                portal = Object.Instantiate(other.gameObject.GetComponent<Nito>().PortalPrefab);
                portal.transform.position = other.gameObject.transform.position + new Vector3(0.0f,-1.10f,0.0f);
                Destroy(other.gameObject);

            }
        }
        else if(other.gameObject.tag == "EnemyJump"){
            other.gameObject.GetComponent<PatrollingEggJump>().life -= 1;
            if(other.gameObject.GetComponent<PatrollingEggJump>().life == -3){
                Destroy(other.gameObject);
            }
        }
    }
}
