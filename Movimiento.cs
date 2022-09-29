using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public float DashForce;
    public bool Left;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private bool DobleSalto;
    private float SaltoCD;
    private float DashCD;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            Left = true;
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Left = false;
        }
        Animator.SetBool("Mum_idle", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.3f))
        {
            Grounded = true;
            DobleSalto = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
            SaltoCD = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && DobleSalto is true && Time.time > SaltoCD + 0.15f)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0);
            Jump();
            DobleSalto = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > DashCD + 0.9f)
        {
            Dash();
        }

    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    private void Dash()
    {
        if (Left == true)
        {
            Rigidbody2D.AddForce(Vector2.left * DashForce);
            //puede servir
            //Rigivody2D.velocity = transform.left*DashForce;
            DashCD = Time.time;
        }
        else
        {
            Rigidbody2D.AddForce(Vector2.right * DashForce);
            DashCD = Time.time;
        }

    }
}
