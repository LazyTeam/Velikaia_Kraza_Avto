using UnityEngine;
using System.Collections;

public class CarCtrl : MonoBehaviour
{

    public float Power, Accelerat, Break, Rotat;
    public string Name;
    public bool Enabl = false;
    private Rigidbody2D pbody;
    public GameObject cam;
    public CamTarg camtar;


    void Start()
    {
        pbody = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        camtar = cam.GetComponent<CamTarg>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Enabl)
        {
            
            camtar.target = GameObject.FindGameObjectWithTag("CAR").transform;
            // tag = "Player";
            double power = Input.GetAxis("Vertical") * Power * Time.deltaTime * 250.0;
            double steer = Input.GetAxis("Horizontal") * Rotat;
            double brake = Input.GetKey("space") ? rigidbody2D.mass * 1000 : 0.0;

            if (Input.GetKey(KeyCode.W))
            {
                pbody.AddRelativeForce(-Vector2.right * (float)power);
            }
            if (Input.GetKey(KeyCode.S))
            {
                pbody.AddRelativeForce(-Vector2.right * (float)power);
            }
            Quaternion quat = Quaternion.identity;
            quat.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z - (float)steer); //Changing angle
            transform.rotation = quat;

        }
        else
        {
            //tag = "CAR";
        }

    }
    void OnGui()
    {
        if (Enabl)
            GUI.Box(new Rect(100, 100, 100, 50), "%s", name);
    }

    
}
