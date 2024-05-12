using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public float hp;
    public GameObject target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
       //select random sprite 
    }

    // Update is called once per frame
    void Update()
    {

        if(hp <=0){
            Destroy(gameObject);
        }
        //move towards target
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.Translate(direction.x * speed * Time.deltaTime, 0, 0);
        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);

        if(distanceToTarget<5.0f){
            Debug.Log("attack");
        }
    }

void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "projectile"
        if (other.CompareTag("projectile"))
        {
            hp-=0.5f;
        }
    }
}
