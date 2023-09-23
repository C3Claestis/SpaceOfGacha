using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summons : MonoBehaviour
{
    public int SpawnRate, JarakStay;
    private float NextSpawn = 0f;

    public GameObject [] Objek;
    public Transform [] Spawn;
    public float Kecepatan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int hasilrandom = Random.Range(0, 2);
        int hasilrandomspawn = Random.Range(0, 10);

        if (Time.time > NextSpawn)
        {
            GameObject newBullet = Instantiate(Objek[hasilrandom], Spawn[hasilrandomspawn].position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Time.fixedTime, Kecepatan);

            NextSpawn = Time.time + SpawnRate;
        }
    }
}
