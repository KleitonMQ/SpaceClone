using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Rigidbody2D tiroRigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        tiroRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // FixedUpdate tem a mesma função do Update(), porem trabalha melhor com objetos contendo rigidbody.
    void FixedUpdate()
    {
        tiroRigidbody.velocity = Vector2.up * speed * Time.deltaTime;
    }
}
