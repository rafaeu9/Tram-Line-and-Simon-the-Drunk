﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area1 : MonoBehaviour
{
    public GameObject Rocket;

    public bool PlayerIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            PlayerIn = true;
    }

    public void Sumon()
    {
        if (PlayerIn)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                PlayerIn = false;
            }       

        }
    }
}
