using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Fase : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject bonus;
    public GameObject bonusSpawn;

    public int quantityLines = 6;
    public int quantityColluns = 5;
    

    private Vector2 initialPosition = new Vector2(2.45f, 2.9f);

    private float countSpawnBonus;
    private int bonusFrequency;
    private int lives;
    private int score;
    private int faseNumber;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        faseNumber = 1;
        bonusFrequency = 15;
        SpawnEnemy();
        FrequencySpawnBonus();

    }

    // Update is called once per frame
    void Update()
    {
        countSpawnBonus += Time.deltaTime;
        SpawnBonus();
        DifficultUp();

    }

    public void SpawnEnemy()
    {
        float spaceHorizontal = 0.9f;
        float spaceVertical = 0.7f;

        Vector2 currentPosition = initialPosition;

        for (int i = 0; i < quantityLines; i++)
        {
            int randonEnemy = Random.Range(0, enemys.Length);

            for (int j = 0; j < quantityColluns; j++)
            {
                GameObject inimigo = Instantiate(enemys[randonEnemy], currentPosition, Quaternion.identity);

                currentPosition.x -= spaceHorizontal;
            }
            currentPosition.y -= spaceVertical;
            currentPosition.x = initialPosition.x;
        }
    }

    void FrequencySpawnBonus()
    {
        bonusFrequency = Random.Range(15, bonusFrequency + faseNumber);
    }

    void SpawnBonus()
    {
        if (countSpawnBonus > bonusFrequency)
        {
            Instantiate(bonus, bonusSpawn.transform.position, Quaternion.identity);
            countSpawnBonus = 0;
            bonusFrequency++;
            FrequencySpawnBonus();
        }

    }

    void DifficultUp()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length > 20)
        {

        }
        switch (enemies.Length)
        {
            case int n when n > 10 && n < 20:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 2f;
                }
                break;

            case int n when n > 5 && n < 11:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 4f;
                }
                break;
            case int n when n > 1 && n < 6:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 6f;
                }
                break;

            case int n when n == 1:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 9f;
                }
                break;

            default:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 1f;
                }
                break;
        }

    }
}
