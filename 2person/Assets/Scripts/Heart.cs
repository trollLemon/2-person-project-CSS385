using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heart : MonoBehaviour
{

    private Image heart;
    // Start is called before the first frame update
    void Start()
    {
     heart = GetComponent<Image>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reduce()
    {
            Color color = heart.color;

            color.a -=0.5f; 

            heart.color = color;

    }
}
