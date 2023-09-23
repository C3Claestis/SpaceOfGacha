using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSummons : MonoBehaviour
{
    public GameObject Summon1, Summon2, Summon3, Summon4, Summon5, Summon6, Summon7;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Summon1.SetActive(true);
            Summon2.SetActive(true);
        }
        if (Score.ScoreCount >= 10)
            Summon3.SetActive(true);

        if (Score.ScoreCount >= 20)
            Summon4.SetActive(true);

        if (Score.ScoreCount >= 50)
            Summon5.SetActive(true);

        if (Score.ScoreCount >= 100)
            Summon6.SetActive(true);

        if (Score.ScoreCount >= 200)
            Summon7.SetActive(true);
    }
}
