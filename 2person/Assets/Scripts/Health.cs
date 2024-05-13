using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float hp = 3;
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
     //hearts= new GameObject[3];   
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void Damage(){
        hp-=0.5f;
        hp = Mathf.Max(hp,0);
        Debug.Log(Mathf.Floor(hp));
        Debug.Log(hp);
        GameObject heartObj = hearts[(int) Mathf.Floor(hp)];

        Heart health = heartObj.GetComponent<Heart>();
        health.Reduce();

    }
}
