using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int Damage;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.KenaDamage(Damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Pembatas") || collision.gameObject.CompareTag("Shield"))
            Destroy(gameObject);

    }
}
