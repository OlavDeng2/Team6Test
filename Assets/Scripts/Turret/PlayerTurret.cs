using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTurret : TurretController {

    public Text currentGunText;
    private GameManager gameManager;

    private void Awake()
    {
        UpdateGunUI();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //if game is not paused, take input for turret.
        if(!gameManager.gameIsPaused)
        {
            base.RotateTurret();
            GetAimPoint();
            
            if (Input.GetButtonDown("Fire"))
            {
                base.FireGun();
            }
            //rotate through guns up or down
            if (Input.GetKeyDown("e"))
            {
                if (currentGun < guns.Length - 1)
                {
                    base.SwapGun(currentGun + 1);
                }
                else if (currentGun == guns.Length - 1)
                {
                    base.SwapGun(0);
                }
                UpdateGunUI();
            }
            if (Input.GetKeyDown("q"))
            {
                if (currentGun > 0)
                {
                    base.SwapGun(currentGun - 1);

                }
                else if (currentGun == 0)
                {
                    base.SwapGun(guns.Length - 1);
                }
                UpdateGunUI();
            }
        }
        
    }

    private void GetAimPoint()
    {
        aimPoint = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
    }

    private void UpdateGunUI()
    {
           currentGunText.text = "Current Gun: " + guns[currentGun];
    }
}
