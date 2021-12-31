using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip shotSound, TeleportSound, jumpSound, EndingSound;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        shotSound = Resources.Load<AudioClip>("Bolinha");
        TeleportSound = Resources.Load<AudioClip>("Teleporte");
        jumpSound = Resources.Load<AudioClip>("Jump");
        EndingSound = Resources.Load<AudioClip>("Ending");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip) {
            case "Shot":
                audioSrc.PlayOneShot(shotSound);
                break;
            case "Teleporte":
                audioSrc.PlayOneShot(TeleportSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "Ending":
                audioSrc.PlayOneShot(EndingSound);
                break;
        }
    }
}
