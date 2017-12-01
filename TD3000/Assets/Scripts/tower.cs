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
    public float fb_damage;
    public float fb_speed;
    public float period;


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered Collision.");
        currentTarget = col.transform;
        InvokeRepeating("FireFireballs", 0.0f, period);
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
        fireball nf = newFireball.GetComponent<fireball>();
        nf.target = currentTarget;
        nf.damage = fb_damage;
        nf.speed = fb_speed;
    }

}
