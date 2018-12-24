using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurret : TurretController {

    private GameObject currentTarget;

    public float reloadTime = 1f;
    private float currentReload;
	
	
	// Update is called once per frame
	void Update () {
        currentReload += Time.deltaTime;

        //Look for target if no target possible, otherwise shoot at target
        if(currentTarget == null)
        {
            currentTarget = GetNewTarget();
        }
        else if(currentTarget)
        {
            GetAimPoint();
            base.RotateTurret(); 
        }

        //Only shoot if have a target and isnt reloading
        if (currentTarget && currentReload > reloadTime)
        {
            currentReload = 0;
            base.FireGun();
        }
	}


    private void GetAimPoint()
    {
        aimPoint = (Vector2)currentTarget.transform.position;
    }

    private GameObject GetNewTarget()
    {
        //only get new target if any exists in the world. Note find is not efficient.
        EnemyController newTarget = FindObjectOfType<EnemyController>();
        if (newTarget)
        {
            return newTarget.gameObject;
        }

        else
        {
            return null;
        }
    }
}
