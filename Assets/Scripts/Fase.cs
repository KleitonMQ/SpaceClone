using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase : MonoBehaviour
{
    public GameObject enemy;

    private int health;
    private int score;
    private int faseNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        health= 3;
        score = 0;
        faseNumber= 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {

    }


}
