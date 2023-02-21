using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private bool showInfo;
    private int maxScore;
    
    public TextMeshProUGUI textScore;
    public GameObject infoHud;

    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = ("Max Score: " + maxScore);

        if (Input.GetKeyDown(KeyCode.Return) && !showInfo)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            showInfo = !showInfo; 
            infoHud.SetActive(showInfo);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showInfo = false;
            infoHud.SetActive(showInfo);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
