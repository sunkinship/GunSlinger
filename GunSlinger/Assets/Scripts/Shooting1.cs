using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting1 : MonoBehaviour
{
    public GameObject Bullet1;
    public Transform FirePoint1;
    public float bulletSpeed = 15f;
    public GameObject Player;
    public bool allowFire;
    public float rateOfFire = 3f;
    



    private void Start()
    {
        allowFire = true;
        
    }

    private void Update()
    {
     

        if (Input.GetKeyDown(KeyCode.R) && (allowFire == true))
        {
            FirePoint1.transform.rotation = Quaternion.Euler(0, 0, 40);
            StartCoroutine(FireUp());
        
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            FirePoint1.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.C) && (allowFire == true))
        {
            FirePoint1.transform.rotation = Quaternion.Euler(0, 0, -40);
            StartCoroutine(FireDown());
      
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            FirePoint1.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.F) && (allowFire == true))
        {
            StartCoroutine(Fire());
            FirePoint1.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    IEnumerator FireUp()
    {
        allowFire = false;

        ShootUp();

        yield return new WaitForSeconds(rateOfFire);

        allowFire = true;
    }

    private void ShootUp()
    {
        GameObject Bullet = Instantiate(Bullet1);
        Bullet.transform.position = FirePoint1.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, 40);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint1.right * bulletSpeed;
    }

    IEnumerator FireDown()
    {
        allowFire = false;

        ShootDown();

        yield return new WaitForSeconds(rateOfFire);

        allowFire = true;
    }

    private void ShootDown()
    {
        GameObject Bullet = Instantiate(Bullet1);
        Bullet.transform.position = FirePoint1.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, -40);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint1.right * bulletSpeed;
    }

    IEnumerator Fire()
    {
        allowFire = false;

        Shoot();

        yield return new WaitForSeconds(rateOfFire);

        allowFire = true;
    }

    private void Shoot()
    {
        GameObject Bullet = Instantiate(Bullet1);
        Bullet.transform.position = FirePoint1.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint1.right * bulletSpeed;
    }
}
