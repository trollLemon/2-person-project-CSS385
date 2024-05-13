using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    private Slider ammoBar;
    public int ammo;
    public int maxAmmo;
    // Start is called before the first frame update
    void Start()
    {
     ammoBar = GetComponent<Slider>();   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseAmmo(int num)
    {
        ammo-=num;
        float ammoPerc = (float)ammo/(float)maxAmmo;
        ammoBar.value = ammoPerc;


    }
}
