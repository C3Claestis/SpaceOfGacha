using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemShield : EnheritItem
{
    private CountShield countShield;
    // Start is called before the first frame update
    void Start()
    {
        countShield = FindObjectOfType<CountShield>(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newBullet = Instantiate(Angka, pos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Speed);

            countShield.gameObject.SetActive(true);
            countShield.HitungShield += 5;
            Destroy(gameObject);
            Destroy(newBullet, 1f);
        }
        else if (collision.gameObject.CompareTag("Pembatas"))
            Destroy(gameObject);
    }
}
