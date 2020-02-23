using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSource; //0がバイク爆発音 1が

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>();
    }

    public void PlaySound(int num)
    {
        if(audioSource.Length > num)
        {
            audioSource[num].Play();
        }
        else
        {
            Debug.Log("そんな音声は無い");
        }
    }

}
