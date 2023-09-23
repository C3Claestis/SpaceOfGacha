using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public GameObject panel,haydar, rildan, piju, jafar, maincredit;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        haydar.SetActive(false);
        rildan.SetActive(false);
        piju.SetActive(false);
        jafar.SetActive(false);
        maincredit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void haydarpanel()
    {
        maincredit.SetActive(false);
        panel.SetActive(false);
        rildan.SetActive(false);
        piju.SetActive(false);
        jafar.SetActive(false);
        haydar.SetActive(true);
    }
    public void rildanpanel()
    {
        maincredit.SetActive(false);
        panel.SetActive(false);        
        piju.SetActive(false);
        jafar.SetActive(false);
        haydar.SetActive(false);
        rildan.SetActive(true);
    }
    public void pijupanel()
    {
        maincredit.SetActive(false);
        panel.SetActive(false);        
        jafar.SetActive(false);
        haydar.SetActive(false);
        rildan.SetActive(false);
        piju.SetActive(true);
    }
    public void jafarpanel()
    {
        maincredit.SetActive(false);
        panel.SetActive(false);        
        haydar.SetActive(false);
        rildan.SetActive(false);
        piju.SetActive(false);
        jafar.SetActive(true);
    }
    public void paneluatama()
    {
        maincredit.SetActive(false);
        haydar.SetActive(false);
        rildan.SetActive(false);
        piju.SetActive(false);
        jafar.SetActive(false);
        panel.SetActive(true);
    }
    public void credit()
    {
        haydar.SetActive(false);
        rildan.SetActive(false);
        piju.SetActive(false);
        jafar.SetActive(false);
        panel.SetActive(false);
        maincredit.SetActive(true);
    }
}
