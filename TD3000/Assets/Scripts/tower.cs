using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    public Transform fireballPreFab;
    private bool inRange = false;
    private Transform currentTarget;
    private Transform newFireball; //fireballs will be "fire and forget" (i.e. no homing)
    private Vector3 differenceVector;
    public float damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered Collision.");
        currentTarget = col.transform;
        InvokeRepeating("FireFireballs", 0.0f, 0.3f);
        //inRange = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exited Collision.");
        CancelInvoke();
        //inRange = false;
    }

    void FireFireballs()
    {
        newFireball = (Transform)Instantiate(fireballPreFab).transform;
        newFireball.position = transform.position; //set the initial position of the fireball
        newFireball.GetComponent<fireball>().target = currentTarget;
        newFireball.GetComponent<fireball>().damage = damage;
    }

}
