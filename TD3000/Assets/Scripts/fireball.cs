using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{

    public Transform target;
    public float damage;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Creep"))
        {
            Debug.Log("collided");
            Creep creep = other.GetComponent<Creep>();
            creep.damage(damage);
            Destroy(this.gameObject);
        }
    }

}
