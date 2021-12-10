using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShootUp();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            ShootDown();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            ShootLeft();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            ShootRight();
        }
    }

    void ShootUp()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointUp.position, firePoint.rotation);
        Rigidbody2D rbU = bullet.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.I))
        {
            rbU.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void ShootDown()
    {
        GameObject bullet2 = Instantiate(bulletPrefab, firePointDown.position, firePoint.rotation);
        Rigidbody2D rbD = bullet2.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.K))
        {
            rbD.AddForce(firePoint.up * -1 * bulletForce, ForceMode2D.Impulse);
        }
    }

    void ShootLeft()
    {
        GameObject bullet3 = Instantiate(bulletPrefab, firePointLeft.position, firePoint.rotation);
        Rigidbody2D rbL = bullet3.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.J))
        {
            rbL.AddForce(firePoint.right * -1 * bulletForce, ForceMode2D.Impulse);
        }
    }

    void ShootRight()
    {
        GameObject bullet4 = Instantiate(bulletPrefab, firePointRight.position, firePoint.rotation);
        Rigidbody2D rbR = bullet4.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.L))
        {
            rbR.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}