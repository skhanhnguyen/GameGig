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
    public Text win;

    bool ready = false;

    public SpawnList[] waves;
	public float[] wave_timers;
    int wave_no = 0;

    public Transform spawn_pos;
    Vector2 spawn_vect;
    float last_spawn_t;

    public Transform[] towers;
    public float[] towers_costs;
    public float[] towers_radii;


    public LayerMask tower_placement_layer;

    SpriteRenderer cursor_image;

    int tower_no = 0;

    // Use this for initialization
    void Start () {
        _instance = this;
        spawn_vect.x = spawn_pos.position.x;
        spawn_vect.y = spawn_pos.position.y;
        last_spawn_t = Time.time;
        cursor_image = Placement.Instance.GetComponent<SpriteRenderer>();
        SetText();
    }
	
	// Update is called once per frame
	void Update () {
        if (wave_no < waves.Length)
        {

			if (Time.time - last_spawn_t > wave_timers[wave_no])
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
        else
        {
            win.text = "You Won!!!";
            //won the game!
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("pressed q");
            tower_no = tower_no - 1;
            if (tower_no < 0)
            {
                tower_no = towers.Length-1;
            }
            SetText();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed e" + tower_no.ToString());
            tower_no = tower_no + 1;
            if (tower_no == towers.Length)
            {
                tower_no = 0;
            }
            SetText();
        }
        if (Input.GetMouseButtonDown(0))
        {
            cursor_image.sprite = towers[tower_no].GetComponent<SpriteRenderer>().sprite;
            Placement.Instance.transform.localScale = towers[tower_no].localScale;
            cursor_image.enabled = true;
            ready = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            cursor_image.enabled = false;
            ready = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (ready)
            {
                place_tower();
                cursor_image.enabled = false;
                ready = false;
            }
        }

	}

    void place_tower()
    {
        if (towers_costs[tower_no] < money)
        {
            Debug.Log("pressed");
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            Vector2 placement_pos;
            placement_pos.x = pz.x;
            placement_pos.y = pz.y;

            Collider2D ans = Physics2D.OverlapCircle(placement_pos, towers_radii[tower_no], tower_placement_layer);
            if (true)
            {
                Instantiate(towers[tower_no], pz, Quaternion.identity);
                money -= towers_costs[tower_no];
                SetText();
            }
        }
    }

    public void EnemyAtBase(float money_cost) {
        money -= money_cost;
        if (money < 0)
        {
            win.text = "You Lost...";
        }
        SetText();
    }

    void SetText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        tower_no.ToString();

        text.text = "Money: " + money.ToString() + " Wave no:" + wave_no.ToString() + " Tower:" + tower_no.ToString();
    }
}
