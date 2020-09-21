using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool followPlayer;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            transform.position = Vector2.Lerp(transform.position,new Vector2(player.transform.position.x,transform.position.y),1f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
