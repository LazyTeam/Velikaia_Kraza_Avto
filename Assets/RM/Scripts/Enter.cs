using UnityEngine;
using System.Collections;

public class Enter : MonoBehaviour {


    private CarCtrl parrent;
	// Use this for initialization
	void Start () {
        parrent = GetComponentInParent<CarCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
       // if (other.gameObject.tag == "Player")
       // {
            if (Input.GetKey(KeyCode.F))
            {
                parrent.Enabl = !parrent.Enabl;
                other.enabled = false;

            }
     //   }
    }
}
