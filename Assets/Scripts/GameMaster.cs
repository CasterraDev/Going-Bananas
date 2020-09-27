using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int lastLevelBananas = 0;
    public int bananas = 0;
    public GameObject bananaTxt;
    protected GameMaster() { }
    public static GameMaster instance = null;

    private AudioSource bgMusic;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        bgMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bananaTxt == null)
        {
            bananaTxt = GameObject.Find("BananaText");

        }
        else
        {
            if (bananas < 0) bananas = 0;
            bananaTxt.GetComponent<Text>().text = bananas.ToString();
        }
        
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        bananas = lastLevelBananas;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
