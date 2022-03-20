using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int scoreGive = 100;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UiManager.obj.UpdateScore();
            AudioManager.obj.PlayCoin();
            Pop.obj.Show(transform.position);
            Game.obj.AddScore(scoreGive);
            gameObject.SetActive(false);
           
        }
    }
}
