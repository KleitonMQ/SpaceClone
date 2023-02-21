using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    Rigidbody2D shootRigidbody;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        shootRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shootRigidbody.velocity = Vector2.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Nave>().Death();
            Inimigo.GameRun = false;
        }
    }
}
