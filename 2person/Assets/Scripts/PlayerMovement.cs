using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LookDirection
{
    Left,
    Right
}
public class PlayerMovement : MonoBehaviour
{

    public int health;
    public int antiBugJuice;

    public float speed;
    private GameObject hand;
    private Vector3 mouseWorldPosition;
    private Camera mainCamera;
    public int handReach = 3;

    private LookDirection lookDirection;

    private SpriteRenderer spr;



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        hand = GameObject.Find("Hand");
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);    
    Aim();
    faceMouse();

     if (Input.GetKey(KeyCode.D)){
        transform.position += Vector3.right * speed * Time.deltaTime;
        }
    if (Input.GetKey(KeyCode.A)){
        transform.position += Vector3.left* speed * Time.deltaTime;
        }
    
    
    }

    private void Aim()
    {
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        Vector2 handUnitCircle = new Vector2(targetDirection.x, targetDirection.y);
        if (handUnitCircle.magnitude > handReach)
        {
            handUnitCircle.Normalize();
            handUnitCircle *= handReach;
        }
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(targetAngle) < 90)
        {
            lookDirection = LookDirection.Right;
        } else
        {
           lookDirection = LookDirection.Left;
        }

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90);
        hand.transform.rotation = Quaternion.RotateTowards(hand.transform.rotation, targetRotation, 1000 * Time.deltaTime);
        hand.transform.position = new Vector3(handUnitCircle.x + transform.position.x, handUnitCircle.y + transform.position.y, transform.position.z - 1);
    }

    private void faceMouse()
    {
        if(lookDirection==LookDirection.Right){
            spr.flipX = true;
        }else{
            spr.flipX = false;
        }
    }

 
}
