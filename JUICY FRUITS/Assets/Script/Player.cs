using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D miRB;

    [SerializeField] private float JumpForce = 5.0f;

    [SerializeField] private bool Suelo;

    [SerializeField] private float velocidad = 3.0f;

    [SerializeField] public float speed;

    private SpriteRenderer mysr;

    public PlayerAnimation mypa;
    void Start()
    {
        miRB = GetComponent<Rigidbody2D>();
        Suelo = true;
        mypa = GetComponent<PlayerAnimation>();
        mysr = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        Movimiento();
        RevisarSuelo();
    }
    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.tag == "Suelo")
        {
            Suelo = true;
        }
    }

    void Movimiento()
    {
        float mover = Input.GetAxisRaw("Horizontal");
        miRB.velocity = new Vector2(mover, miRB.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Suelo == true)
        {
            miRB.velocity = new Vector2(miRB.velocity.y, JumpForce);
            Suelo = false;
        }
       if(mover > 0)
        {
            transform.localScale = new Vector3(0.1915658f, transform.localScale.y, transform.localScale.z);
        }else if (mover < 0)
        {
            transform.localScale = new Vector3(-0.1915658f, transform.localScale.y, transform.localScale.z);
        }

        mypa.Mover(mover);
    }
    
    void RevisarSuelo()
    {
        Vector3 movement = new Vector2(miRB.velocity.x, JumpForce);
        miRB.AddForce(movement * speed);
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, Vector2.down * 0.5f, 0.7f, 1 << 8);

        if (HitInfo.collider != null)
        {
            Suelo = true;
        }
    }
}
