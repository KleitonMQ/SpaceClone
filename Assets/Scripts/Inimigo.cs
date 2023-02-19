using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Animator enemyAnimator;
    public GameObject enemyShoot;
    public Transform enemyShootPoint;
    private Transform enemyTransform;

    public int direcao;
    public int spriteFrame;
    private float enemySpeed;

    private bool canShoot;
    private int sortShoot;
    public int countShoot;
    public float shoot;

    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyTransform= GetComponent<Transform>();

        direcao= 1;
        isAlive= true;
        spriteFrame= 0;

        CanShoot();
        

    }

    // Update is called once per frame
    void Update()
    {
        enemySpeed =+ 1 * Time.deltaTime;
        UseSpriteFrame();
        Shoot();
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
        if (enemySpeed>1 && direcao==1)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x - 0.2f, enemyTransform.position.y, enemyTransform.position.z);
        }
        if (enemySpeed>1 && direcao==0)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x + 0.2f, enemyTransform.position.y, enemyTransform.position.z);

        }
    }
    void UseSpriteFrame()
    {
        enemyAnimator.SetInteger("transition", 0);
    }

    private void CanShoot()
    {
        sortShoot = Random.Range(0, 10);
        if (sortShoot < 5)
        {
            canShoot = true;
            countShoot = Random.Range(0, 10);
        }
        else canShoot= false;
    }

}
