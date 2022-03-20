using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public int scoreGive = 30;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cuore");
            UiManager.obj.UpdateLives();
            UiManager.obj.UpdateScore();
            FxManager.obj.ShowPop(transform.position);
            Player.obj.AddLive();
            gameObject.SetActive(false);
        }
    }
}
