using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int velocity = 0;
    private Rigidbody2D MyMB2D;

    public int Mindmg = 15;
    public int Maxdmg = 60;

    // Start is called before the first frame update
    void Start()
    {
        MyMB2D = gameObject.GetComponent<Rigidbody2D>();
        
        MyMB2D.velocity = transform.right * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Enemy"))
                collision.GetComponent<EarthElem>().Damage(Random.Range(Mindmg, Maxdmg));
            else if(collision.CompareTag("BlockRock"))
                Destroy(collision.gameObject);
            
            if (collision.CompareTag("Area"))
            {
                
            }
            
                Destroy(gameObject);
            
        }
    }
}
