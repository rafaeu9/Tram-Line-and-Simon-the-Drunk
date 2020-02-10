using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public GameObject rocket;
    private Transform Pointer;

    public float timeBtwShots;
    public float CoolDown;

    public GameObject text;
    private Text buttontext;

    private Rigidbody2D MyRigid;

    public float MoveSpeed;
    Vector2 direction;

    public int HP = 80;
    public int MaxHP = 80;

    public Slider life;
    public GameObject RepairSlider;
    public GameObject RepairButton;
    bool reparing = false;
    public int HPTick = 6;
    public int timeRepair = 10;
    int timeRepairTick = 0;
    float repairTick = 1;
    float DeltaTimeRepair = 0;
    




    // Start is called before the first frame update
    void Start()
    {
        Pointer = transform.Find("Pointer");
        MyRigid = GetComponent<Rigidbody2D>();
        buttontext = text.GetComponent<Text>();
    }     
    
    // Update is called once per frame
    void Update()
    {

        if(reparing)
        {
            DeltaTimeRepair += Time.deltaTime;
            if(repairTick < DeltaTimeRepair)
            {
                HP += HPTick;
                DeltaTimeRepair = 0;
                ++timeRepairTick;
                RepairSlider.GetComponent<Slider>().value = timeRepairTick;
            }

            if (timeRepair < timeRepairTick)
                reparing = false;


            if (HP > MaxHP)
            {
                HP = MaxHP;
                reparing = false;
            }

        }else if(!reparing && RepairSlider.activeSelf)
        {
            RepairSlider.SetActive(false);
        }

        if (timeBtwShots > 0)
        {
            timeBtwShots -= Time.deltaTime;
            buttontext.text = ((int)timeBtwShots).ToString();
        }
        else
        {
            timeBtwShots = 0;
            buttontext.text = "";
        }

        Vector3 MoveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

        if (MoveVec.x != 0 || MoveVec.y != 0)
        {
            if (reparing)
                reparing = false;

            var angle = Mathf.Atan2(MoveVec.y, MoveVec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (MoveVec.magnitude > 1)
            {
                MoveVec = MoveVec.normalized;
            }

            MyRigid.velocity = MoveVec * MoveSpeed;
        }
        else
            MyRigid.velocity = Vector2.zero;


        life.value = HP;


        if (HP <= 0)
            KillPlayer();

    }

    public void Shot()
    {
        if (timeBtwShots == 0)
        {
            Instantiate(rocket, Pointer.position, Pointer.rotation);
            timeBtwShots = CoolDown;
        }
    }

    public void Damage(int dmg)
    {
        HP -= dmg;

        if (reparing)
            reparing = false;
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Repair()
    {
        RepairButton.SetActive(false);
        RepairSlider.SetActive(true);

        reparing = true;
    }

}
