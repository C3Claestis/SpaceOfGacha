using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnheritEnemy
{
    public GameObject[] item;
    public Transform  ShotPoss, ItemShot;
    private float nextspwan = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        int hasilrandom = Random.Range(0, 4);
        if (Time.time >= nextattacktime)
        {   
            nextattacktime = Time.time + TimeShoot;
            GameObject newBullett = Instantiate(bullet, ShotPos.position, Quaternion.identity);
            newBullett.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan);
        }
        if (Time.time >= nextspwan)
        {
            nextspwan = Time.time + TimeShoot + 1f;
            GameObject newBulleets = Instantiate(bullet, ShotPoss.position, Quaternion.identity);
            newBulleets.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan);
        }
        if (currentHP <= 100)
            anim.SetBool("Action", true);

        if (currentHP <= 0)
        {
            GameObject newBulletss = Instantiate(item[hasilrandom], ShotPos.position, Quaternion.identity);
            newBulletss.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan = -1);

            GameObject newBullet = Instantiate(Angka, pos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Speed);

            Score.ScoreCount += 25;
            Destroy(gameObject);
            Destroy(newBullet, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject newBullet = Instantiate(Angka, pos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Speed);

            Score.ScoreCount += 25;
            Destroy(gameObject);
            player.KenaDamage(10);
            Destroy(newBullet, 1f);
        }
        else if (collision.gameObject.tag == "Pembatas")
        {
            player.KenaDamage(10);
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
}
