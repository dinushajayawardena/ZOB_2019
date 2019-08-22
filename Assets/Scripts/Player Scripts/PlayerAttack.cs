using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    public float hit_Score;

    public static float current_Score;

    public GameObject score_Shower;

    public int selected_No;

    public float timer = 0f;

    public GameObject b_Target1;
    public GameObject b_Target2;
    public GameObject b_Target3;
    public GameObject b_Target4;
    public GameObject b_Target5;
    public GameObject b_Target6;
    public GameObject b_Target7;
    public GameObject b_Target8;


    // Start is called before the first frame update
    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        //get the animator component in FP camera - child in child component of the parent "Player"

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);//get the crosshair from the gameobjects

        mainCam = Camera.main; //set the main camera object to maincam camera type variable

    }


    private void Start()
    {
        current_Score = 0;

        b_Target1.SetActive(false);
        b_Target2.SetActive(false);
        b_Target3.SetActive(false);
        b_Target4.SetActive(false);
        b_Target5.SetActive(false);
        b_Target6.SetActive(false);
        b_Target7.SetActive(false);
        b_Target8.SetActive(false);

        InvokeRepeating("RandomNoGenerator", 5f, 4f);

    }
    // Update is called once per frame
    void Update()
    {
        

        WeaponShoot();
        ZoomInAndOut();
        GetScore();
        //RandomNoGenerator();
        
    }

    void WeaponShoot()
    {
        
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType==WeaponFireType.MULTIPLE)//if player selected assault rifle
        {
            if(Input.GetMouseButton(0) && Time.time >nextTimeToFire) //check whether the player is press and hold the left mouse button & make fire continously
            {
                
                    nextTimeToFire = Time.time + 1f / fireRate;

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFiredBasic(); // call function to get the hit gameobject name
                
            }

            
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.SINGLE)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                BulletFiredBasic(); //  call function to get the hit gameobject name
            }
        }

        
    }

    void ZoomInAndOut() //make zoom in and out
    {
        if(weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim==WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);// play the zoom animation

                crosshair.SetActive(false);//deactive the crosshair
            }

            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);// play the zoom animation

                crosshair.SetActive(true);//active the crosshair
            }
        }
    }

    //public float BulletFired() //detect the collision of gameobjects when fired
    //{
    //    RaycastHit hit;
    //    current_Score += hit_Score;
    //    //Debug.Log(current_Score);

    //    score_Shower.GetComponent<Text>().text = current_Score.ToString(); 
        
    //    if(Physics.Raycast(mainCam.transform.position , mainCam.transform.forward, out hit))
    //    {
    //        if(hit.transform.gameObject.name == "ring0")
    //        {
    //            //print("ring0 get hitted");
    //            hit_Score = 5f;
    //            return hit_Score;
    //        }

    //        if (hit.transform.gameObject.name == "ring1")
    //        {
    //            //print("ring0 get hitted");
    //            hit_Score = 4f;
    //            return hit_Score;
    //        }

    //        if (hit.transform.gameObject.name == "ring2")
    //        {
    //            //print("ring0 get hitted");
    //            hit_Score = 3f;
    //            return hit_Score;
    //        }

    //        if (hit.transform.gameObject.name == "ring3")
    //        {
    //            //print("ring0 get hitted");
    //            hit_Score = 2f;
    //            return hit_Score;
    //        }

    //        if (hit.transform.gameObject.name == "ring4")
    //        {
    //            //print("ring0 get hitted");
    //            hit_Score = 1f;
    //            return hit_Score;
    //        }

    //        if (hit.transform.gameObject.name == "ring5")
    //        {
    //            //print("ring0 get hitted");
    //            hit_Score = 0.5f;
    //            return hit_Score;
    //        }

    //        //print("a bullet hits to: "+hit.transform.gameObject.name); //get the name of the hitted gameobject.
    //        hit_Score = 0f;
    //        return hit_Score;
    //    }
    //    hit_Score = 0f;
    //    return 0;

        
    //}

    public float BulletFiredBasic()
    {
        RaycastHit hit;
        current_Score += hit_Score;

        score_Shower.GetComponent<Text>().text = current_Score.ToString();

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.name == "Basic_Target" && WeaponHandler.bullets_Left !=0 && WeaponHandler.bullets_To_Load != WeaponHandler.bullets_Per_Mag)
            {
                hit_Score = 2f;
                return hit_Score;
            }
            else
                hit_Score = 0;
            return hit_Score;
            //print("a bullet hits to: " + hit.transform.gameObject.name); //get the name of the hitted gameobject.
        }
        return 0;
    }
    float GetScore()
    {
        return current_Score;
    }

    void RandomNoGenerator()
    {
        b_Target1.SetActive(false);
        b_Target2.SetActive(false);
        b_Target3.SetActive(false);
        b_Target4.SetActive(false);
        b_Target5.SetActive(false);
        b_Target6.SetActive(false);
        b_Target7.SetActive(false);
        b_Target8.SetActive(false);

            selected_No = Random.Range(1, 9);
            print("random number is: "+selected_No);
            switch (selected_No)
            {
                case 1:
                    b_Target1.SetActive(true);
                    break;

                case 2:
                    b_Target2.SetActive(true);
                    break;

                case 3:
                    b_Target3.SetActive(true);
                    break;

                case 4:
                    b_Target4.SetActive(true);
                    break;

                case 5:
                    b_Target5.SetActive(true);
                    break;

                case 6:
                    b_Target6.SetActive(true);
                    break;

                case 7:
                    b_Target7.SetActive(true);
                    break;

                case 8:
                    b_Target8.SetActive(true);
                    break;

                    timer = 0;

            }
        
    }


}
