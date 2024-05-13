using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


    public GameObject projectileObj;
    public int projectileSpeed = 5;
    public Ammo ammo;
    // Start is called before the first frame update
    void Start()
    {
       ammo = GameObject.Find("BugJuice").GetComponent<Ammo>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(ammo.ammo <=0) return;
            ammo.UseAmmo(1);
            ShootProj();
        }
    }

    void ShootProj()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the mouse position is at the same Z position as the shooter

        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject projectile = Instantiate(projectileObj, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Example: If you're using Rigidbody2D for physics
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed; // Adjust projectileSpeed as needed
        }
        else
        {
            Debug.LogError("Projectile prefab must have a Rigidbody2D component.");
        }
    }
}
