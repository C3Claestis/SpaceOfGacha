using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnheritEnemy
{
    public GameObject[] item;
    public GameObject bullets;
    public Transform  ShotPoss, ShotPosss, ItemShot;
    int hasilrandom;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        hasilrandom = Random.Range(0, 2);
        if (currentHP > 400)
        StartCoroutine(Shoot());

        if (currentHP <= 400)
        {
            anim.SetBool("Action", true);
            StopCoroutine(Shoot());
            StartCoroutine(TransformShoot());
        }            

        if (currentHP <= 0)
        {
            GameObject newBullet = Instantiate(item[hasilrandom], ShotPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan = -1);

            GameObject newBullets = Instantiate(Angka, pos.position, Quaternion.identity);
            newBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Speed);

            Score.ScoreCount += 50;
            Destroy(gameObject);
            Destroy(newBullets, 1f);
        }
    }

    IEnumerator Shoot()
    {
        if (Time.time >= nextattacktime)
        {
            nextattacktime = Time.time + TimeShoot;
            yield return new WaitForSeconds(0f);
            GameObject newBullet = Instantiate(bullet, ShotPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan);
        }
    }

    IEnumerator TransformShoot()
    {
        if (Time.time >= nextattacktime)
        {
            nextattacktime = Time.time + TimeShoot;
            yield return new WaitForSeconds(0f);

            GameObject newBullet = Instantiate(bullets, ShotPoss.position, Quaternion.identity);
            GameObject newBullets = Instantiate(bullets, ShotPosss.position, Quaternion.identity);

            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan = -15);
            newBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan = -15);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newBullet = Instantiate(Angka, pos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Speed);

            Score.ScoreCount += 50;
            Destroy(gameObject);
            player.KenaDamage(20);
            Destroy(newBullet, 1f);
        }
        else if(collision.gameObject.CompareTag("Teritory"))
        {
            player.KenaDamage(20);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            anim.SetTrigger("Hurt");
        }
        if (collision.gameObject.CompareTag("Bullet 2"))
        {
            
            anim.SetTrigger("Hurt");
        }
    }
  /*  private void FixedUpdate()
    {
        rb.velocity = new Vector2(gerak, rb.velocity.x);
    }*/
}
