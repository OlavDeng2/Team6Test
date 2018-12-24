using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : Gun {

    public float enemyMoveSpeed = 0.5f;

    public override void DamageEnemy()
    {
        enemyController.moveSpeed = enemyMoveSpeed;
    }
}
