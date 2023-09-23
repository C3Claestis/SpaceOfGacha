using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalScore : MonoBehaviour
{
    float scores;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        float nilai = Score.ScoreCount;
        float time = FinishTimer.waktu;
        text = GetComponent<Text>();
        scores = nilai + time;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = scores.ToString();
    }
}
