using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountSwift : MonoBehaviour
{
    public float HitungSwift;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = HitungSwift.ToString();

        HitungSwift -= Time.deltaTime;

        if (HitungSwift < 0)
            gameObject.SetActive(false);

    }
}
