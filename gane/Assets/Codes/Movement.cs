using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    public static float speed = 6;
    public float x;
    public float y;
    public Rigidbody body;


    public bool CanJump;
    public LayerMask mask;

    Vector3 die;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        ShootRay();
    }

    void TakeInput() 
    {
        
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    
    }

    private void FixedUpdate()
    {
        Movment();

        if (CanJump && Input.GetKey(KeyCode.Space))
        {

            jump();
        
        }
    }


    void Movment() 
    {
        
        die = x*Vector3.right * speed + y*Vector3.forward * speed;  

        body.velocity = die;    
    
    }

    void ShootRay() 
    {
        CanJump = Physics.Raycast(transform.position, Vector3.down, 2, mask);
    
    }

    void jump() 
    {
        
        body.velocity = new Vector3(body.velocity.x, 0, body.velocity.z);
        
        body.AddForce(transform.up * 2, ForceMode.Impulse);
    
    }

}
