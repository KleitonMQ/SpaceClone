using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase : MonoBehaviour
{
    public GameObject[] enemys;
    public int quantityLines = 6;
    public int quantityColluns = 5;

    private Vector2 initialPosition= new Vector2(2.45f,2.9f);

    private int health;
    private int score;
    private int faseNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        health= 3;
        score = 0;
        faseNumber= 1;
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        float spaceHorizontal = 0.9f;
        float spaceVertical = 0.7f;

        Vector2 currentPosition = initialPosition;

        for (int i=0; i<quantityLines; i++)
        {
            int randonEnemy = Random.Range(0, enemys.Length);

            for (int j=0; j<quantityColluns; j++)
            {
                GameObject inimigo = Instantiate(enemys[randonEnemy], currentPosition, Quaternion.identity);

                currentPosition.x -= spaceHorizontal;
            }
            currentPosition.y -= spaceVertical;
            currentPosition.x = initialPosition.x;
        }
    }


}
