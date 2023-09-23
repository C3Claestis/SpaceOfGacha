using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnheritEnemy
{   
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextattacktime)
        {
            nextattacktime = Time.time + TimeShoot;
            GameObject newBullet = Instantiate(bullet, ShotPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan);
        }

        if (currentHP <= 50)
            anim.SetBool("Action", true);

        if (currentHP <= 0)
        {
            GameObject newBullet = Instantiate(Angka, pos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Speed);

            Score.ScoreCount += 10;
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

            Score.ScoreCount += 10;
            Destroy(gameObject);
            player.KenaDamage(5);
            Destroy(newBullet, 1f);
        }
        else if (collision.gameObject.tag == "Pembatas")
        {
            player.KenaDamage(5);
            Destroy(gameObject);
        }
            
        if (collision.gameObject.CompareTag("Bullet"))
        {            
            anim.SetTrigger("Hurt");
        }   
        if(collision.gameObject.CompareTag("Bullet 2"))
        {         
            anim.SetTrigger("Hurt");
        }
    }
}
