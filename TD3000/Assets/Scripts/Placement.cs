using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

    static Placement _instance;
    public static Placement Instance { get { return _instance; } }

    // Use this for initialization
    void Start ()
    {
        _instance = this;
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        transform.position = pz;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        transform.position = pz;
    }
}
