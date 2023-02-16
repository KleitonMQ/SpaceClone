using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed;
    public bool isIlive;

    private Rigidbody2D shipRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        shipRigidbody.velocity = new Vector2(movement * speed, shipRigidbody.velocity.y);


    }
    void Shoot()
    {

    }
}
