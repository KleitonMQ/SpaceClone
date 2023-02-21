using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private int maxScore;
    public TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("score");
        
            textScore.text = ("Max Score: " + maxScore);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
}
