using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour {

    GameManager gameManager;

    public int maxEnemies = 3;
    private int enemiesGottenPast;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
{
        //Count enemies getting past and Gameover if more than the limit has come past
        enemiesGottenPast++;
        Destroy(collision.gameObject);

        if(enemiesGottenPast >= maxEnemies)
        {
            gameManager.GameOver();
        }
    }
}
