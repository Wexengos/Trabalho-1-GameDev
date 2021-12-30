using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    public static AudioSource audioSrc;
    public static AudioClip ending;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ending = Resources.Load<AudioClip>("Ending");
        audioSrc.PlayOneShot(ending);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
