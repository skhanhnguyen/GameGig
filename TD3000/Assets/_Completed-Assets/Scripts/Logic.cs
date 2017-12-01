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
    public Text money_text;
    public Vector2 spawn_area;

    float last_spawn_t;

    public Transform creep1prefab;

    public SpawnList[] waves;
    int wave_no = 0;

    // Use this for initialization
    void Start () {
        _instance = this;
        SetMoneyText();
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
                    Instantiate(creep, spawn_area + Random.insideUnitCircle, Quaternion.identity);
                }
                wave_no += 1;
                last_spawn_t = Time.time;
                SetMoneyText();
            }
        }
        else
        {
            //won the game!
        }
	}

    public void EnemyAtBase(float money_cost) {
        money -= money_cost;
        SetMoneyText();
    }

    void SetMoneyText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        money_text.text = "Money: " + money.ToString() + " Wave no:" + wave_no.ToString();
    }
}
