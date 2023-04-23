using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_Obj : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip scarySound;
    public GameObject ScaryMimic;
    bool isPlayed;

    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
        soundSource.clip = scarySound;
    }

    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag == "Player") {
            StartCoroutine(scare());
         }
    }

    IEnumerator scare()
    {
            if(!isPlayed) {
            soundSource.Play();
            ScaryMimic.SetActive(true);
            isPlayed = true;
            }
        yield return new WaitForSeconds(1);
            ScaryMimic.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
