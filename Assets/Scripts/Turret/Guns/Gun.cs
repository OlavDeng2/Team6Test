using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    private RaycastHit2D raycastHit;
    public EnemyController enemyController;

    public GameObject bullet;
    public int bulletSpeed;

    public float damage = 1;

    public virtual void Shoot(Vector3 aimDirection)
    {
        raycastHit = Physics2D.Raycast(transform.position, aimDirection, Mathf.Infinity);

        //check if enemy hit and then damage enemy
        if (raycastHit)
        {
            enemyController = raycastHit.collider.GetComponent<EnemyController>();
            DamageEnemy();
        }

        //Instantiate graphic for bullet
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);

        //Converting the inputted aim directyion to angle then converting it back to vector2 as otherwise it seems distance between click and turret affects bullet speed
        //might be missing something obvious
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Vector2 fireDirection = Vector3.Normalize(Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right);

        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = fireDirection * bulletSpeed;   //aimDirection.normalized * bulletSpeed;

        Destroy(newBullet, 5f);        
    }

    public virtual void DamageEnemy()
    {
        enemyController.health -= damage;
    }

    
}
