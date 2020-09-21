using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int bananasToUnlock = 3;

    private GameMaster gm;
    private bool hasEnough;
    // Start is called before the first frame update
    void Start()
    {
        hasEnough = false;
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        Text text = GameObject.Find("UnlockText").GetComponent<Text>();
        text.text = bananasToUnlock.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gm != null) gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        if (Input.GetKeyDown(KeyCode.E) && gm.bananas >= bananasToUnlock && collision.CompareTag("Player"))
        {
            Debug.Log("Next Scene");
            gm.bananas -= bananasToUnlock;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
