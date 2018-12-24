using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public GameObject turret;
    private GameObject placableTurret;

    private GameManager gameManager;

    private bool placingTurret = false;

	// Use this for initialization
	void Awake () {
        //Get the gameManager for use to get the score to buy things
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire") && placingTurret)
        {
            PlaceTurret();
        }
    }

    public void BuyTurret()
    {
        if(gameManager.score >= 5)
        {
            gameManager.score -= 5;
            placingTurret = true;
        }
    }


    private void PlaceTurret()
    {
        //get the location to place the turret based on the current mouse position
        Instantiate(turret, new Vector3(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition).x, Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition).y, 0), this.transform.rotation);
        placingTurret = false;
    }
}
