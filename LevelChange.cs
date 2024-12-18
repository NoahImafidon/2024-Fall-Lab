using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    int score = 0; 
    public int scoreValue = 10; 
    
    Text scoreNumber; 

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 

            
            scoreNumber = GameObject.Find("scoreNumber").GetComponent<Text>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int points)
    {
        score += points; 
        scoreNumber.text = score.ToString();
    }


    public void GoToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;


        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
