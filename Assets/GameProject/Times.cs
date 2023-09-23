using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Times : MonoBehaviour
{
    private int SpawnRate = 1;
    public static int Timer;

    [HideInInspector]
    public float NextSpawn = 0f;
    
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 90;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Timer.ToString();
        //Timer -= 1;

        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            Timer -= 1; 
        }
    }
}
