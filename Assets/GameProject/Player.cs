using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;

    Rigidbody2D rb;
    private float KecepatanBullet, TimeShoot, dirX, dirY, Speed, nextattacktime = 0f;
    public GameObject bullet, bullet2, Wings, DeathDisplay, ClearDisplay;
    public Transform ShotPos, ShotPosTransform1, ShotPosTransform2;

    [HideInInspector]
    public bool Kondisi;
    [HideInInspector]
    public int MaxHP = 100, currentHP;
    private CountShield countShield;
    private CountBerserk countBerserk;
    private CountSwift countSwift;

    [SerializeField]
    FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        Speed = 5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        countShield = FindObjectOfType<CountShield>();
        countBerserk = FindObjectOfType<CountBerserk>();
        countSwift = FindObjectOfType<CountSwift>();
        TimeShoot = 1f;
        Kondisi = false;
    }

    public void KenaDamage(int damage)
    {
        currentHP -= damage;
    }
    // Update is called once per frame
    void Update()
    {
        //Pergerakan
        dirY = joystick.Vertical * Speed;
        dirX = joystick.Horizontal * Speed;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -3.5f, 3.5f),
            Mathf.Clamp(transform.position.y, -5.5f, 6.5f));

        //Menembak
        if (Kondisi == true)
        {

            if (currentHP >= 70)
            {
                DefaultShoot();
                StopCoroutine(Bullet2());
                StopCoroutine(TransformShoot());
                StartCoroutine(DefaultShoot());
            }

            else if (currentHP >= 40 && currentHP < 70)
            {                
                StopCoroutine(DefaultShoot());
                StopCoroutine(Bullet2());
                StartCoroutine(TransformShoot());
            }
            else if(currentHP < 40 )
            {             
                StopCoroutine(DefaultShoot());
                StopCoroutine(TransformShoot());
                StartCoroutine(Bullet2());
            }
        }
   
        else if (Kondisi == false)
        {
            StopAllCoroutines();
        }
        
        //MAX HP
        if (currentHP >= 101)
            currentHP = 100;

        if (currentHP < 0)
            currentHP = 0;

        //Animasi
        if (countShield.HitungShield > 0)        
            anim.SetBool("Shield", true);        
            
        else if(countShield.HitungShield <= 0)        
            anim.SetBool("Shield", false);
        
        if (countBerserk.HitungBerserk > 0)        
            anim.SetBool("Berserk", true);
        
        else if(countBerserk.HitungBerserk <= 0)        
            anim.SetBool("Berserk", false);

        if (countBerserk.HitungBerserk > 0 && countShield.HitungShield > 0)
            anim.SetTrigger("ShieldBerserk");

        else if (countBerserk.HitungBerserk <= 0 && countShield.HitungShield <= 0)
            anim.SetTrigger("Idle");

        if (countShield.HitungShield > 0 && countBerserk.HitungBerserk <= 0)
            anim.SetTrigger("Shields");

        else if (countBerserk.HitungBerserk > 0 && countShield.HitungShield <= 0)
            anim.SetTrigger("Berserks");

        //Switch Berserk Swift

        if (countBerserk.HitungBerserk > 0 && currentHP >= 70)
            TimeShoot = 0.5f;
           
         else if (countBerserk.HitungBerserk <= 0 && currentHP >= 70)
            TimeShoot = 1f;

        if (countBerserk.HitungBerserk > 0 && currentHP < 70)
            TimeShoot = 1f;

        else if (countBerserk.HitungBerserk <= 0 && currentHP < 70)
            TimeShoot = 2f;

        if (countSwift.HitungSwift > 0)
        {
            Wings.SetActive(true);
            Speed = 10f;
        }
            
        else if (countSwift.HitungSwift <= 0)
        {
            Wings.SetActive(false);
            Speed = 5f;
        }

        //Display
        if (currentHP <= 0)
        {
            DeathDisplay.SetActive(true);
            Time.timeScale = 0;            
        }
        if (Times.Timer <= 0)
        {
            ClearDisplay.SetActive(true);
            Time.timeScale = 0;            
        }
    }

    public IEnumerator DefaultShoot()
    {
        if (Time.time >= nextattacktime) 
        { 
            nextattacktime = Time.time + TimeShoot;

            yield return new WaitForSeconds(0f);
            GameObject newBullet = Instantiate(bullet, ShotPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, KecepatanBullet = 30);
        }
    }

    public IEnumerator Bullet2()
    {
        if (Time.time >= nextattacktime)
        {
            nextattacktime = Time.time + TimeShoot;

            yield return new WaitForSeconds(0f);
            GameObject newBullet = Instantiate(bullet2, ShotPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, KecepatanBullet = 10);
        }
    }

    public IEnumerator TransformShoot()
    {
        if (Time.time >= nextattacktime)
        {
            nextattacktime = Time.time + TimeShoot;

            yield return new WaitForSeconds(0f);
            GameObject newBullet = Instantiate(bullet, ShotPosTransform1.position, Quaternion.identity);
            GameObject newBullets = Instantiate(bullet, ShotPosTransform2.position, Quaternion.identity); 
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, KecepatanBullet = 20);
            newBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, KecepatanBullet = 20);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }
}
