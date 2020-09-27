using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;

    [HideInInspector]
    public int health;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) KillSelf();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void KillSelf()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<GameMaster>().RestartLevel();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
