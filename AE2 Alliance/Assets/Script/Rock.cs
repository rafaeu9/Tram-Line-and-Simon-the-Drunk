using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int Mindmg = 10;
    public int Maxdmg = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Player"))
                collision.GetComponent<Player>().Damage(Random.Range(Mindmg, Maxdmg));

            Destroy(gameObject);
        }
    }

}
