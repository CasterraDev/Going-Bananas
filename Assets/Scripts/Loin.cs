using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loin : Enemy
{
    public AudioClip growlClip;
    private AudioSource growlAS;

    private float timer;
    private float timerCD = 20;

    private void Awake()
    {
        timer = Time.time + timerCD * Time.deltaTime;
        growlAS = gameObject.AddComponent<AudioSource>();
        growlAS.clip = growlClip;
        Loin[] loins = GameObject.FindObjectsOfType<Loin>();
        timerCD *= loins.Length;
    }

    public override void Update()
    {
        base.Update();
        if (timer < Time.time) {
            if (!growlAS.isPlaying)
            {
                float r = Random.Range(0, 30);
                Debug.Log(r);
                if (r <= 1)
                {
                    growlAS.Play();
                }
                timer = Time.time + timerCD * Time.deltaTime;
            }
        }
        
    }
}
