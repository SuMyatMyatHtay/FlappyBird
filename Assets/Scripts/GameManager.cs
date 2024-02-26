using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager me;
    public bool CanFly;
    public HighestScoreScriptableObject HighestScoreScriptableObject;
    private float Score; 
    private TextMeshProUGUI ScoreText;
    private TextMeshProUGUI EndScore;
    private TextMeshProUGUI BestScore; 
    private GameObject GameOverCanvas; 
    public void Awake()
    {
        me = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EndScore = GameObject.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        BestScore = GameObject.Find("BestScore").GetComponent <TextMeshProUGUI>();
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        GameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");

        GameOverCanvas.SetActive(false); 
        CanFly = true; 
        Score = 0; 
        ScoreText.text = Score.ToString();

        BestScore.text = HighestScoreScriptableObject.HighScore.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameOver()
    {
        print("GameOver from GameManager script"); 

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (var pipe in pipes)
        {
            movePipeScript movePipeScript = pipe.GetComponent<movePipeScript>(); 
            if (movePipeScript != null) {
                movePipeScript.enabled = false; 
            } 
        }

        gameObject.GetComponent<SpawnPipeScript>().enabled = false;
        CanFly = false;

        GameOverCanvas.SetActive(true);
        HighScoreCheck(); 
    }

    public void IncreaseScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }

    public void RestartScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GoBackHome()
    {
        SceneManager.LoadScene("MenuScene");
    }

    
    public void HighScoreCheck()
    {
        if(HighestScoreScriptableObject.HighScore < Score)
        {
            HighestScoreScriptableObject.HighScore = Score; 
        }
        BestScore.text = HighestScoreScriptableObject.HighScore.ToString();
        EndScore.text = Score.ToString();
    }

    
}
