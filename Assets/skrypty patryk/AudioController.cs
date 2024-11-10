using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
 public AudioClip czekanie;
    public AudioClip walka;
    public Movement movement;
    public AudioSource source;

    public void Start()
    {
        source.clip = czekanie;
        source.Play();
    }

    private void Update()
    {
       
    }

   
}
