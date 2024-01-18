using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components
    private Rigidbody2D Rb;

    //move
    [SerializeField] private float Speed;
    private float Horizontal;
    // private float Vertical;  8-Directional Movement
    // private Vector2 Direction;  8-Directional Movement
    private bool IsFacingRight;

    //junp
    [SerializeField] private float JunpForce;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float Range;
    private bool inGround;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        Junp();
    }

    private void Movements()
    {

        /*
        8-Directional Movement
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Direction = new Vector2(Horizontal, Vertical);
        Direction = Direction.normalized;
        Rb.velocity = Direction * Speed;
        */

        //Side Scrolling Movement
        Horizontal = Input.GetAxisRaw("Horizontal");
        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
        
    }

    private void Junp()
    {
        inGround = Physics2D.OverlapCircle(feetPosition.position, Range, Ground);

        if (Input.GetKeyDown(KeyCode.Space) && inGround)
        {
            Rb.velocity = Vector2.up * JunpForce;
        }
    }

    private void Flip()
    {
        //Changes Direction of Object
        if (IsFacingRight && Horizontal > 0f || !IsFacingRight && Horizontal < 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPosition.position, Range);
    }
}
