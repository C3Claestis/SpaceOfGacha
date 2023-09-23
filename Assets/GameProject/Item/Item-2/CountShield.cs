using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountShield : MonoBehaviour
{
    public float HitungShield;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = HitungShield.ToString();

        HitungShield -= Time.deltaTime;
       
        if (HitungShield < 0)
            gameObject.SetActive(false);
    }
}
