using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class OrangeMonster : MonoBehaviour
{
    private bool moveRight;

    Rigidbody2D rb;
    Vector2 position;

    private Checkpoint checkpoint;
    private SavePoint sp;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveRight = true;
        position = new Vector2(-10f, -0.08f);
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Checkpoint>();
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();

    }

    private void FixedUpdate()
    {
        if (moveRight == true)
            MoveRight();

        if (moveRight == false)
            MoveLeft();


    }

    void MoveRight()
    {
        rb.MovePosition(position);
        //rb.MoveRotation(position.x * 72);
        position.x += 0.05f;
        //position.y += 0.5f*Mathf.Sin(2*Mathf.PI*position.x);
        if (position.x >= -8)
        {
            moveRight = false;
            Flip();
        }
    }
    void MoveLeft()
    {
        rb.MovePosition(position);
        //rb.MoveRotation(position.x * 72);
        position.x -= 0.05f;
        //position.y -= 0.5f*Mathf.Sin(2*Mathf.PI*position.x);
        if (position.x <= -10)
        {
            moveRight = true;
            Flip();
        }

    }
    void Flip()
    {
        if (moveRight == true)
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        if (moveRight == false)
            gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = other.GetContact(0).normal;
            if (direction.y == -1 || direction.y == 1)
            {
                GetComponent<Collider2D>().enabled = false;

                Score.Instance.AddHundoPeice();

                Destroy(this.gameObject, 0.1f);

            }
            else
            {
                other.gameObject.transform.position = sp.lastCheckPointPos;
                checkpoint.dead = true;
            }
        }

    }
}