using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;
    public float health;

    private Rigidbody2D rb;

    public GameManager gameManager;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        move();
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }

    private void move()
    {
        rb.velocity = this.transform.right * moveSpeed;
    }

    private void OnDestroy()
    {
        gameManager.score++;
    }
}
