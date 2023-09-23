using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanel : MonoBehaviour
{

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
