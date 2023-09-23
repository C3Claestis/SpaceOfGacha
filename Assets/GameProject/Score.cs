using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreCount;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCount = ScoreCount;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ScoreCount.ToString();
    }
}
