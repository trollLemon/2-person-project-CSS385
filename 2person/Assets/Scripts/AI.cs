using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int damageInterval = 5;
    public int damageAmount = 5;

    public float hp;
    public GameObject target;
 
    public Objective obj;
    public float speed = 5f;
    public bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
      target = GameObject.Find("Stem");
      obj = target.GetComponent<Objective>();
      
      hp=5; 
    }

    // Update is called once per frame
    void Update()
    {

        if(hp <=0){
            obj.enemyKilled();
            Destroy(gameObject);
        }
        //move towards target
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.Translate(direction.x * speed * Time.deltaTime, 0, 0);
        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);

        if(distanceToTarget<5.0f){
            if(!attacking)
                StartCoroutine(DealDamageOverTime());

        }
    }
    IEnumerator DealDamageOverTime()
    {
        while (gameObject != null)
        {
            yield return new WaitForSeconds(damageInterval);
            obj.takeDamage(damageAmount);
        }
        attacking = false;
    }



void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("a");
        // Check if the colliding object has the tag "projectile"
        if (other.CompareTag("projectile"))
        {
            hp-=1;
            Destroy(other.gameObject);
        }
 
    }
}
