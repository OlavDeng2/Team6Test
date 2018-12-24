using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public float rotateSpeed;
    public Vector3 aimPoint { get; set; }
    public Vector3 aimDirection { get; set; }

    public GameObject[] guns;
    public int currentGun = 0;
    public GameObject turretGun;
    private Gun turretGunScript;

    private void Start()
    {
        //Get the gun so we can get info to later replace its position
        turretGun = GetComponentInChildren<Gun>().gameObject;
        turretGunScript = GetComponentInChildren<Gun>();

    }

    public void RotateTurret()
    {
        //rotate the turret at a set speed
        aimDirection = Vector3.Normalize(aimPoint - this.transform.position);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
    }

    public void FireGun()
    {
        turretGunScript.Shoot(aimDirection);
    }


    //Swap the gun for whatever gun is wanted
    public void SwapGun(int gunWanted)
    {
        Transform spawnInfo = turretGun.transform;
        Destroy(turretGun);

        currentGun = gunWanted;
        turretGun = Instantiate(guns[currentGun], spawnInfo.position, spawnInfo.rotation, this.transform);

        turretGunScript = turretGun.GetComponent<Gun>();

    }
}
