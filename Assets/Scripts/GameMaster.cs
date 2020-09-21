using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int bananas = 0;
    public GameObject bananaTxt;

    // Start is called before the first frame update
    void Start()
    {
        bananaTxt = GameObject.Find("BananaText");
    }

    // Update is called once per frame
    void Update()
    {
        if (bananas < 0) bananas = 0;
        bananaTxt.GetComponent<Text>().text = bananas.ToString();
    }
}
