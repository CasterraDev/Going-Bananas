using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float spd = 10f;
    public float jumpForce = 5f;
    public LayerMask whatIsGround;
    public Animator anim;

    private BoxCollider2D boxCol;
    private Rigidbody2D rb;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(h * spd * Time.deltaTime,0));

        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jumpForce;
            anim.SetTrigger("Jump");
        }

        if (h > 0 && !facingRight) Flip();
        if (h < 0 && facingRight) Flip();

        if (h != 0 && IsGrounded()) anim.SetTrigger("Walking");
        if (h == 0) anim.SetTrigger("Idle");
    }

    bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycast = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0, Vector2.down, boxCol.bounds.extents.y + extraHeight, whatIsGround);
        return raycast.collider != null;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
