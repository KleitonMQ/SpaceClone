using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    static public bool GameRun;

    
    private Animator enemyAnimator;
    public GameObject enemyShoot;
    public Transform enemyShootPoint;
    private Transform enemyTransform;
    private Fase fase;
    public AudioSource explosionSound;

    private bool collisionOcurred;
    private int sortShoot;
    private bool canShoot;

    public bool enemyCanDown;
    public int direction;
    public int spriteFrame;
    public float enemyMove;
    public float enemySpeed;
    public int countShoot;
    public float shoot;
    public bool isAlive;
    public int scorePoint;
    // Start is called before the first frame update
    void Start()
    {
        explosionSound.Stop();
        enemyAnimator = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();

        GameRun= true;
        enemyCanDown= true;
        enemySpeed = 1f;
        enemyMove = 0;
        direction = 1;
        isAlive = true;
        spriteFrame = 0;
        collisionOcurred = false;

        CanShoot();

        fase= FindObjectOfType<Fase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (GameRun)
            {
                enemyMove += enemySpeed * Time.deltaTime;
                UseSpriteFrame();
                Shoot();
                Move();
            }
        }
    }

    void Shoot()
    {
        shoot += Time.deltaTime;
        if (canShoot && shoot > countShoot)
        {
            Instantiate(enemyShoot, enemyShootPoint.position, enemyShootPoint.rotation);
            shoot= 0;
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
        sortShoot = Random.Range(0, 15);
        if (sortShoot < 7)
        {
            canShoot = true;
            countShoot = Random.Range(10, 30);
        }
        else canShoot = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "WallLeft" && !collisionOcurred)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                collisionOcurred = true;
                enemy.GetComponent<Inimigo>().ChangeDirectionLeft();
                
            }
        }
        if (collision.gameObject.tag == "WallRight" && !collisionOcurred)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                collisionOcurred = true;
                enemy.GetComponent<Inimigo>().ChangeDirectionRight();

            }
        }
        if (collision.gameObject.tag =="Player")
        {
            var player = collision.gameObject.GetComponent<Nave>();
            player.Death();
            Explosion();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "WallRight" || collision.gameObject.tag == "WallLeft") && collisionOcurred)
        { 
            

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                collisionOcurred = true;
                collisionOcurred = false;
                enemy.GetComponent<Inimigo>().EnemyCanDown();

            }
        }
    }

    void ChangeDirectionLeft()
    {
        direction = -1;
        EnemyDown();
    }
    void ChangeDirectionRight()
    {

        direction = 1;
        EnemyDown();

    }

    void EnemyDown()
    {
        if (enemyCanDown)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x, enemyTransform.position.y - 0.1f, enemyTransform.position.z);
            enemyCanDown= false;
        }
        
    }
    void EnemyCanDown()
    {
        enemyCanDown = true;
    }

    public void Explosion()
    {
        isAlive = false;
        fase.AddScore(scorePoint);
        GetComponent<BoxCollider2D>().enabled= false;
        enemyAnimator.SetBool("explosion", true);
        explosionSound.Play();
        Invoke(nameof(Destroy), 0.5f);
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
