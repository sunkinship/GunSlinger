using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
    public GameObject Bullet2;
    public Transform FirePoint2;
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


        if (Input.GetKeyDown(KeyCode.B) && (allowFire == true))
        {
            FirePoint2.transform.rotation = Quaternion.Euler(0, 0, 140);
            StartCoroutine(FireUp());

        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            FirePoint2.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKeyDown(KeyCode.M) && (allowFire == true))
        {
            FirePoint2.transform.rotation = Quaternion.Euler(0, 0, 220);
            StartCoroutine(FireDown());

        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            FirePoint2.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKeyDown(KeyCode.N) && (allowFire == true))
        {
            StartCoroutine(Fire());
            FirePoint2.transform.rotation = Quaternion.Euler(0, 0, 180);

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
        GameObject Bullet = Instantiate(Bullet2);
        Bullet.transform.position = FirePoint2.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, 140);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint2.right * bulletSpeed;
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
        GameObject Bullet = Instantiate(Bullet2);
        Bullet.transform.position = FirePoint2.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, 220);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint2.right * bulletSpeed;
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
        GameObject Bullet = Instantiate(Bullet2);
        Bullet.transform.position = FirePoint2.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint2.right * bulletSpeed;
    }
}
