using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    private float cooldown;
    private float timer;
    private float gp = 5;
    private float[] xSpawns;
    private float[] ySpawns;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 3;
        timer = 3 + gp;
        xSpawns = new float[2];
        xSpawns[0] = -39.25f;
        xSpawns[1] = 39;
        ySpawns = new float[4];
        ySpawns[0] = -7.5f;
        ySpawns[1] = -3.5f;
        ySpawns[2] = 1.5f;
        ySpawns[3] = 6.5f;
        enemies = Resources.LoadAll<GameObject>("Prefabs");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = cooldown;
            float x = xSpawns[Random.Range(0, xSpawns.Length)];
            float y = ySpawns[Random.Range(0, ySpawns.Length)];
            int enemyIndex = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[enemyIndex]);
            enemy.transform.position = new Vector3(x, y, 0);
        }
    }
}
