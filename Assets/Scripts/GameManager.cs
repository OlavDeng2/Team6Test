using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score { get; set; }
    public int timePerDay = 60;
    public float timeRemaining;

    public float enemySpawnRate;
    public GameObject enemy;

    private IEnumerator playGame;

    private UIManager uiManager;

    public bool gameIsPaused = false;

    // Use this for initialization
    void Start() {
        score = 0;
        timeRemaining = timePerDay;

        uiManager = FindObjectOfType<UIManager>();

        playGame = SpawnEnemies();

        StartDay();
    }

    private IEnumerator SpawnEnemies()
    {
        //go for the length of "day"
        for (int t = timePerDay; t > 0; t--)
        {
            timeRemaining = t;
            //spawn enemies based on enemy spawn rate and give them a random y position
            for (int y = 0; y < enemySpawnRate; y++)
            {

                Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(-4, 4), 0);
                Instantiate(enemy, spawnPos, this.transform.rotation);
            }

            yield return new WaitForSeconds(1f);
        }
        EndDay();
    }

    

    public void StartDay()
    {
        //reassign the play game coroutine otherwise it wont restart on a new day
        playGame = SpawnEnemies();
        timeRemaining = 60;
        uiManager.ResumeGame();
        gameIsPaused = false;
        StartCoroutine(playGame);
    }

    private void EndDay()
    {
        StopCoroutine(playGame);
        ClearAllEnemies();
        gameIsPaused = true;
        uiManager.OpenStore();
    }

    public void GameOver()
    {
        StopCoroutine(playGame);
        ClearAllEnemies();
        uiManager.GameOver();
        gameIsPaused = true;
        
        
    }

    private void ClearAllEnemies()
    {
        //find all the enemies in the scene to then destroy them.
        EnemyController[] enemiesPresent = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in enemiesPresent)
        {
            Destroy(enemy.gameObject);
        }

    }

    
}
