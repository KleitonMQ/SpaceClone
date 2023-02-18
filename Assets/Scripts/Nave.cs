using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed;
    public bool isIlive;
    public bool canShoot;
    private float countDown;

    public GameObject shoot;
    public Transform shootPoint;

    private Rigidbody2D shipRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
        canShoot= true; 
        countDown= 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        shipRigidbody.velocity = new Vector2(movement * speed, shipRigidbody.velocity.y);


    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(shoot, shootPoint.position, shootPoint.rotation);
                countDown= 1f;
            }
        }
        if (!canShoot)
        {
            countDown -= Time.deltaTime;
            if (countDown <=0)
            {
                canShoot= true;
            }
        }
        //StartCoroutine("Fire");
    }
    void Deadh()
    {

    }

 /*   IEnumerable Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(shoot, shootPoint.position, shootPoint.rotation);
                yield return new WaitForSeconds(0.3f);
                canShoot = true;
            }

        }
    }*/
}
