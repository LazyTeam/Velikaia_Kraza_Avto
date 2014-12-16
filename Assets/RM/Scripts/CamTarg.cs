using UnityEngine;
using System.Collections;

public class CamTarg : MonoBehaviour {

    private Vector3 CamTarget;
    public Transform target;
	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
        CamTarget = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, CamTarget, Time.deltaTime * 8);
	}
}
