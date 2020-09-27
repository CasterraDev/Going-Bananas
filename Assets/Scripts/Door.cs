using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int bananasToUnlock = 3;
    public TextMeshProUGUI eTxt;

    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        Text text = GameObject.Find("UnlockText").GetComponent<Text>();
        text.text = bananasToUnlock.ToString();
        eTxt.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        if (Input.GetKeyDown(KeyCode.E) && gm.bananas >= bananasToUnlock && collision.CompareTag("Player"))
        {
            Debug.Log("Next Scene");
            gm.bananas -= bananasToUnlock;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        eTxt.alpha = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        if (Input.GetKeyDown(KeyCode.E) && gm.bananas >= bananasToUnlock && collision.CompareTag("Player"))
        {
            Debug.Log("Next Scene");
            gm.bananas -= bananasToUnlock;
            gm.lastLevelBananas = gm.bananas;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        eTxt.alpha = 0;
    }
}
