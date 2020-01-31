using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        menu.gameObject.SetActive(true);
        this.gameObject.SendMessage("Dead");
        menu.gameObject.SendMessage("GameOver");
    }
}
