using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{

    [SerializeField] float fltLoadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashFSX;
    
    bool boolHasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !boolHasCrashed)
        {
            boolHasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashFSX);
            Invoke("ReloadScene", fltLoadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
