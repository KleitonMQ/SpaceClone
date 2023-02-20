using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Rigidbody2D shootRigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        shootRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // FixedUpdate tem a mesma função do Update(), porem trabalha melhor com objetos contendo rigidbody.
    void FixedUpdate()
    {
        shootRigidbody.velocity = Vector2.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Inimigo>().Explosion();
            Destroy(gameObject);
        }
    }
}
