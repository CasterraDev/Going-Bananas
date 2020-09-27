using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxSpd = 5f;
    public float turnBackAroundLength;
    public Transform groundDetection;
    public LayerMask whatIsGround;
    public AudioClip attackingAudio;

    private GameObject player;
    private AudioSource audioSrc;

    float spd;
    bool facingRight = false;

    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = attackingAudio;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.Translate(Vector3.right * spd * Time.deltaTime);

        if (facingRight)
        {
            spd = maxSpd;
            dir = Vector2.right;
        }
        else
        {
            spd = -maxSpd;
            dir = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, groundDetection.position.y), dir, turnBackAroundLength, whatIsGround);
        if (hit.collider != null)
        {
            Flip();
        }

        RaycastHit2D groundHit = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundHit.collider == null)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("esfdsfdf");
            player.GetComponent<Health>().TakeDamage(1);
            Attack();
        }
    }

    public void Attack()
    {
        audioSrc.Play();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawLine(new Vector3(transform.position.x, groundDetection.position.y), new Vector3(transform.position.x + .5f, groundDetection.position.y));
    }
}
