using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[System.Serializable]
public class SpawnList
{
    public Transform[] spawn_list;
}

public class Logic : MonoBehaviour {

    static Logic _instance;
    public static Logic Instance{get{return _instance; }}
    public float money;
    public Text text;

    public SpawnList[] waves;
    int wave_no = 0;

    public Transform spawn_pos;
    Vector2 spawn_vect;
    float last_spawn_t;

    public Transform[] towers;
    public float[] towers_costs;

    int tower_no = 0;

    // Use this for initialization
    void Start () {
        _instance = this;
        spawn_vect.x = spawn_pos.position.x;
        spawn_vect.y = spawn_pos.position.y;
        last_spawn_t = Time.time;
        SetText();
    }
	
	// Update is called once per frame
	void Update () {
        if (wave_no < waves.Length)
        {

            if (Time.time - last_spawn_t > 1)
            {
                SpawnList wave = waves[wave_no];
                foreach (Transform creep in wave.spawn_list)
                {

                    Instantiate(creep, spawn_vect + Random.insideUnitCircle, Quaternion.identity);
                }
                wave_no += 1;
                last_spawn_t = Time.time;
                SetText();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tower_no -= 1;
            if (tower_no < 0)
            {
                tower_no = towers.Length;
            }
            SetText();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tower_no += 1;
            if (tower_no == towers.Length)
            {
                tower_no = 0;
            }
            SetText();
        }
        if (Input.GetMouseButtonDown(0))
        {
            place_tower();
        }
        else
        {
            //won the game!
        }
	}

    void place_tower()
    {
        //Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pz.z = 0;
        //Instantiate(Tower_no, pz, Quaternion.identity);
    }

    public void EnemyAtBase(float money_cost) {
        money -= money_cost;
        SetText();
    }

    void SetText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        text.text = "Money: " + money.ToString() + " Wave no:" + wave_no.ToString() + " Tower:" + tower_no.ToString();
    }
}
