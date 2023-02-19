using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Animator enemyAnimator;
    public GameObject enemyShoot;
    public Transform enemyShootPoint;
    private Transform enemyTransform;

    public int direction;
    public int spriteFrame;
    public float enemyMove;
    public float enemySpeed;
    private bool canShoot;
    private int sortShoot;
    public int countShoot;
    public float shoot;

    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();

        enemySpeed = 0.5f;
        enemyMove = 0;
        direction = 1;
        isAlive = true;
        spriteFrame = 0;

        CanShoot();


    }

    // Update is called once per frame
    void Update()
    {
        enemyMove += enemySpeed * Time.deltaTime;
        UseSpriteFrame();
        //Shoot();
        Move();
    }

    void Shoot()
    {
        shoot += Time.deltaTime;
        if (canShoot && shoot > countShoot)
        {
            Instantiate(enemyShoot, enemyShootPoint.position, enemyShootPoint.rotation);
        }
    }
    void Move()
    {
        if (enemyMove > 1 && direction == 1)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x - 0.2f, enemyTransform.position.y, enemyTransform.position.z);
            enemyMove = 0;
            if (spriteFrame == 0) spriteFrame = 1;
            else spriteFrame = 0;
        }
        if (enemyMove > 1 && direction == -1)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x + 0.2f, enemyTransform.position.y, enemyTransform.position.z);
            enemyMove = 0;
            if (spriteFrame == 0) spriteFrame = 1;
            else spriteFrame = 0;
        }

    }
    void UseSpriteFrame()
    {
        enemyAnimator.SetInteger("transition", spriteFrame);
    }

    private void CanShoot()
    {
        sortShoot = Random.Range(0, 10);
        if (sortShoot < 5)
        {
            canShoot = true;
            countShoot = Random.Range(0, 10);
        }
        else canShoot = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "WallLeft")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Inimigo>().ChangeDirection();
                
            }
        }
        if (collision.gameObject.tag == "WallRight")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Inimigo>().ChangeDirection();

            }
        }
    }

    void ChangeDirection()
    {

        direction *= -1;
    }
}
