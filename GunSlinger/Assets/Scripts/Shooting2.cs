using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
    public GameObject Bullet1;
    public Transform FirePoint2;
    public float bulletSpeed = 13f;
    public GameObject Player;
    public bool allowFire;
    public float rateOfFire = 2f;
    public Sprite RedBall;
    public Sprite BrownBall;




    private void Start()
    {
        allowFire = true;
        FirePoint2.transform.rotation = Quaternion.Euler(0, 0, 180);

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
        GameObject Bullet = Instantiate(Bullet1);
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
        GameObject Bullet = Instantiate(Bullet1);
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
        GameObject Bullet = Instantiate(Bullet1);
        Bullet.transform.position = FirePoint2.position;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
        Bullet.GetComponent<Rigidbody2D>().velocity = FirePoint2.right * bulletSpeed;
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
