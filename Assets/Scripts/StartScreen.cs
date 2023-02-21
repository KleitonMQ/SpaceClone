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

    public AudioSource startSound;
    public AudioSource musicScreen;

    // Start is called before the first frame update
    void Start()
    {
        startSound.Stop();
        maxScore = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = ("Max Score: " + maxScore);

        if (Input.GetKeyDown(KeyCode.Return) && !showInfo)
        {
            showInfo= !showInfo;
            startSound.Play();
            Invoke(nameof(StartGame),0.5f);
            
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

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
