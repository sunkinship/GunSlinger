using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting1 : MonoBehaviour
{
    public GameObject Bullet1;
    public Transform FirePoint1;
    public float bulletSpeed = 13f;
    public GameObject Player;
    public bool allowFire;
    public float rateOfFire = 2f;
    public Sprite RedBall;
    public Sprite BrownBall;



    private void Start()
    {
        allowFire = true;
        FirePoint1.transform.rotation = Quaternion.Euler(0, 0, 0);

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


    //taking damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = RedBall;

        yield return new WaitForSeconds(0.2f);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = BrownBall;

    }


}
