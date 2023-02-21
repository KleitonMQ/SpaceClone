using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public static bool gameOver;
    public float speed;
    public bool isIlive;
    public bool canShoot;
    private float countDown;
    public bool hitOnce;

    public GameObject shoot;
    public Transform shootPoint;

    private Rigidbody2D shipRigidbody;
    private Animator naveAnimator;

    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        naveAnimator = GetComponent<Animator>();
        shipRigidbody = GetComponent<Rigidbody2D>();
        canShoot= true; 
        countDown= 0;
        isIlive= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIlive)
        {
            Move();
            Shoot();
        }
        else
        {
            shipRigidbody.velocity = new Vector2(0, 0);
        }
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        if (movement > 0 && transform.position.x < 2.55)
        {
            shipRigidbody.velocity = new Vector2(movement * speed, shipRigidbody.velocity.y);
        }

        if (movement < 0 && transform.position.x > -2.55)
        {
            shipRigidbody.velocity = new Vector2(movement * speed, shipRigidbody.velocity.y);
        }

        if (transform.position.x < -2.55)
            transform.position = new Vector2(-2.55f, transform.position.y);

        if (transform.position.x > 2.55)
            transform.position = new Vector2(2.55f, transform.position.y);
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(shoot, shootPoint.position, shootPoint.rotation);
                countDown= 0.7f;
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
    }

    public void Death()
    {
        naveAnimator.SetInteger("explosion", 1);
        isIlive = false;
        OnDeath?.Invoke();
        if (!gameOver)
        {
            Invoke(nameof(AfterDeath), 2f);
        }
    }

    void AfterDeath()
    {
        naveAnimator.SetInteger("explosion", 0);
        transform.position = new Vector3(0f, -4.637913f);
        isIlive = true;
        Inimigo.GameRun = true;
        hitOnce= false;
    }
}
