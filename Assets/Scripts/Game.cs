using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj;

    public int maxLives = 3;
    public bool gamePaused = false;
    public int score = 0;
   


    void Awake()
    {
        obj = this;
    }

    void Start()
    {
        gamePaused = false;
        UiManager.obj.StartGame();
    }
    
  public void AddScore(int scoreGive)
    {
        score += scoreGive;
        UiManager.obj.UpdateLives();
    }

   
    void OnDestroy()
    {
        obj = null;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
