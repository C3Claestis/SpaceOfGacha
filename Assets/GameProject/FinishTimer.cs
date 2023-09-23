using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTimer : MonoBehaviour
{
    public static float waktu = 0;
    
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        waktu = Mathf.Round(waktu);
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        waktu += Time.deltaTime;
        text.text = waktu.ToString();
    }
}
