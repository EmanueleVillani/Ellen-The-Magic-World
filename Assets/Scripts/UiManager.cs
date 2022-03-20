using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager obj;
    public Text livesText;
    public Text scoreText;
    public Transform UIPanel;
  
    void Awake()
    {
        obj = this;
    }

    public void UpdateLives()
    {
        livesText.text = "" + Player.obj.lives;
        
    }

    public void UpdateScore()
    {
        scoreText.text = "" + Game.obj.score;
    }

    public void StartGame()
    {
        AudioManager.obj.PlayGui();
        Game.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }
    public void HidePanelUi()
    {
        AudioManager.obj.PlayGui();
        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        obj = null;
    }

}
