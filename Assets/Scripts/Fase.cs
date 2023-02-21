using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fase : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject bonus;
    public GameObject bonusSpawn;
    public GameObject lifeSprite;
    public TextMeshProUGUI scoreText;

    public int quantityLines = 6;
    public int quantityColluns = 5;


    private Vector2 initialPosition = new Vector2(2.45f, 2.9f);
    private Vector2 initialPositionLife = new Vector2(2.86f, 4.74f);

    private float countSpawnBonus;
    private int bonusFrequency;
    private int lives;
    private int score;
    private int maxScore;
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

        Nave nave = FindObjectOfType<Nave>();


        // Inscreve o método OnNaveDeath() no evento OnDeath da classe Nave
        nave.OnDeath += OnNaveDeath;
    }

    // Update is called once per frame
    void Update()
    {
        countSpawnBonus += Time.deltaTime;
        SpawnBonus();
        DifficultUp();
        EnemyCount();
        LifeController();
        ShowScore();
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
                    enemy.GetComponent<Inimigo>().enemySpeed = 1f + faseNumber;
                }
                break;

            case int n when n > 5 && n < 11:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 4f + faseNumber;
                }
                break;
            case int n when n > 1 && n < 6:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 6f + faseNumber;
                }
                break;

            case int n when n == 1:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 9f + faseNumber;
                }
                break;

            default:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Inimigo>().enemySpeed = 1f + faseNumber;
                }
                break;
        }
    }

    public void EnemyCount()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            faseNumber++;
            SpawnEnemy();
        }
    }
    public void LifeController()
    {
        float spaceHorizontal = 0.3f;
        
        Vector2 currentPosition = initialPositionLife;
        GameObject[] lifes = GameObject.FindGameObjectsWithTag("Life");

        if (lifes.Length < lives)
        {
            for (int i = 0; i < lives; i++)
            {

                GameObject life = Instantiate(lifeSprite, currentPosition, Quaternion.identity);

                currentPosition.x -= spaceHorizontal;
            }
        }

        if (lifes.Length > lives)
        {
            foreach (GameObject life in lifes)
            Destroy(life);
        }
    }
    void OnNaveDeath()
    {
        lives--;
    }

    public void AddScore(int scorePoint)
    {
        score += scorePoint;
    }
    void ShowScore()
    {
        scoreText.text = "Score: " + score;
    }
}
