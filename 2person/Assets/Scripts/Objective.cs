using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public Text gameOver;

    private float startingYScale = 4;
    private int enemiesKilled;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, startingYScale, 0);
        level2.SetActive(false);
        level3.SetActive(false);
        gameOver.enabled = false;
        enemiesKilled = 0;
        health = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyKilled()
    {
        enemiesKilled++;

        // Upgrades Plant
        switch(enemiesKilled)
        {
            case 5:
                level1.transform.localScale = new Vector3(1, 10, 1);
                break;

            case 10:
                transform.localScale = new Vector3(1, startingYScale + 4, 1);
                level2.SetActive(true);
                break;

            case 15:
                level1.transform.localScale = new Vector3(1, 15, 1);
                level2.transform.localScale = new Vector3(1, 10, 1);
                break;

            case 20:
                transform.localScale = new Vector3(1, startingYScale + 8, 1);
                level3.SetActive(true);
                break;
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            gameOver.enabled = true;
        }
    }

}
