using UnityEngine;
using System.Collections;

public class CharCtrl : MonoBehaviour {


    public float Speed,SpeedR,NSpeed;
    private Rigidbody2D Physics;
    public GameObject cam;

	// Use this for initialization
	void Start () {
        Physics = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
	}

    public void EnterCar()
    {
        transform.Translate(Vector3.up);
    }
	
	// Update is called once per frame
	void Update () 
    {

        Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);        //Mouse position
        Vector3 objpos = Camera.main.WorldToViewportPoint(transform.position);        //Object position on screen
        Vector2 relobjpos = new Vector2(objpos.x - 0.5f, objpos.y - 0.5f);            //Set coordinates relative to object
        Vector2 relmousepos = new Vector2(mouse.x - 0.5f, mouse.y - 0.5f) - relobjpos;
        float angle = Vector2.Angle(Vector2.up, relmousepos);    //Angle calculation
        if (relmousepos.x > 0)
            angle = 360 - angle;
        Quaternion quat = Quaternion.identity;
        quat.eulerAngles = new Vector3(0,0,angle); //Changing angle
        transform.rotation = quat;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            NSpeed =  SpeedR;
        }
        else
        {
            NSpeed = Speed;
        }
        float vert, hor;
        float iswalkdir = Input.GetAxis("Vertical");
        if (iswalkdir != 0)
        {
            relmousepos.Normalize();
            vert = iswalkdir * (NSpeed / 100) * relmousepos.y;
            hor = iswalkdir * (NSpeed / 100) * relmousepos.x;
            transform.position = new Vector3(transform.position.x + hor, transform.position.y + vert, transform.position.z);
        }
        GameObject sp = GameObject.Find("Sphere");
        Vector3 rot = new Vector2(Mathf.Cos(transform.rotation.z) - 0.5f, Mathf.Sin(transform.rotation.z) - 0.5f);
        
        
        sp.transform.position = new Vector3(transform.position.x + rot.x, transform.position.y + rot.y, transform.position.z);
        float iswalkside = Input.GetAxis("Horizontal");
        /*if (iswalkside != 0)
        {
            Vector3 rot;
            if (iswalkside > 0)
            {
                
               // rot = new Vector3(Mathf.Cos(rotat.z), Mathf.Sin(rotat.z), 0);
            }
            else
            {
                //rot = new Vector3(Mathf.Cos(rotat.z), Mathf.Sin(rotat.z), 0);
            }
            rot.Normalize();
            vert = iswalkside * (NSpeed / 100) * rot.y;
            hor = iswalkside * (NSpeed / 100) * rot.x;
            transform.position = new Vector3(transform.position.x + hor, transform.position.y + vert, transform.position.z);
        }*/
	}
}
