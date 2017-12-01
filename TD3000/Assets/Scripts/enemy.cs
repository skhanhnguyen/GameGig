using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += 4 * Time.deltaTime;
        transform.position = temp;
    }

}
