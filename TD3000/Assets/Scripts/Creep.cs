using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class Creep : MonoBehaviour
{

    public float speed;             //Floating point variable to store the creep speed.
    public float life;              //Floating point variable to store the creep life.
    public float money_cost;
    public Vector2 dir;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(dir * speed * rb2d.mass);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Base"
        if (other.gameObject.CompareTag("Base"))
        {
            //Add one to the current value of our count variable.
            Logic.Instance.EnemyAtBase(money_cost);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Redirect"))
        {
            dir = other.gameObject.GetComponent<Redirect>().dir;
        }
    }

    public void damage(float d)
    {
        life -= d;
        if (life < 0)
        {
            Logic.Instance.EnemyAtBase(-money_cost);
            Destroy(this.gameObject);
        }
    }
}
