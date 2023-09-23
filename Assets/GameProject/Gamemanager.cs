using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject panel, panelmenu, panelmode, paneleasy, panelmedium, panelhard;
    private Player player;
  
    public void Start()
    {
        Time.timeScale = 1;
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
       
    }
    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Mulai()
    {
        panelmenu.SetActive(false);
        panelmode.SetActive(true);
    }
    public void Back()
    {
        panelmode.SetActive(false);
        panelmenu.SetActive(true);
    }
  
    public void Credit()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void easymode() 
    {
        paneleasy.SetActive(true);
        panelmode.SetActive(false);
    }
    public void mulaieasy()
    {
        paneleasy.SetActive(false);
        SceneManager.LoadScene(2);
        Score.ScoreCount = 0;
        Time.timeScale = 1;        
    }
    public void mediummode()
    {
        panelmedium.SetActive(true);
        panelmode.SetActive(false);
    }
    public void mulaimedium()
    {
        panelmedium.SetActive(false);
        SceneManager.LoadScene(3);
        Score.ScoreCount = 0;
        Time.timeScale = 1;
    }
    public void hardmode()
    {
        panelhard.SetActive(true);
        panelmode.SetActive(false);
    }
    public void mulaihard()
    {
        panelhard.SetActive(false);
        SceneManager.LoadScene(4);
        Score.ScoreCount = 0;
        Time.timeScale = 1;
    }
    public void tembak()
    {
        player.Kondisi = true;       
    }
    public void nontembak()
    {
        player.Kondisi = false;
    }
}
