using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGun : Gun {

    public float enemyMoveSpeed = 0.5f;
	
    public override void DamageEnemy()
    {
        base.DamageEnemy();
        enemyController.moveSpeed = enemyMoveSpeed;
    }
}
