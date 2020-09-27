using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Health health;
    public Text healthTxt;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthTxt = GameObject.Find("Health Text").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        healthTxt.text = health.health.ToString();
    }
}
