using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthElem : MonoBehaviour
{
    public GameObject rock;
    public GameObject player;
    public GameObject rocket;

    public float CoolDown = 5;
    public float timeBtwShots = 0;

    public float rockSpeed;
        
    public int HP = 50;

    public float range;

    public GameObject Sumon;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);



        timeBtwShots += Time.deltaTime;
        if (timeBtwShots >= CoolDown)
        {
            if (Vector3.SqrMagnitude(player.transform.position - transform.position) < range)
            {
                GameObject GO = Instantiate(rock, transform.position, transform.rotation);
                GO.GetComponent<Rigidbody2D>().velocity = dir.normalized * rockSpeed;
                timeBtwShots = 0;
            }
            
        }

        if (HP <= 0)
        {
            if(Sumon)
            Sumon.SetActive(true);

            Destroy(gameObject);
        }
    }

    public void Damage(int dmg)
    {
        HP -= dmg;
    }
}
