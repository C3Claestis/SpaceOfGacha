using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnheritEnemy : MonoBehaviour
{
    protected int currentHP;
    public int MaxHP;
    public Animator anim;

    public float gerak;

    public float TimeShoot, Kecepatan;
    protected float nextattacktime = 0f;

    protected Player player;
    protected Rigidbody2D rb;

    public Transform pos, ShotPos;
    public GameObject Angka, bullet;
    protected float diry, Speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
