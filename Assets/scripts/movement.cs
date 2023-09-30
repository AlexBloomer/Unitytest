using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float startSpeed = 5;
    private float speed = 5;
    public float jumpHeight = 1;
    bool leftPressed;
    bool rightPressed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // helloooo
    }

    // Update is called once per frame
    void Update()
    {
        if(leftPressed || rightPressed)
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void right(){
        speed = startSpeed;
        rightPressed = true;
    }

    public void left(){
        speed = -startSpeed;
        leftPressed = true;
    }

    public void rightUp(){
        rightPressed = false;
    }

    public void leftUp(){
        leftPressed = false;;
    }

    public void jump(){
        if(GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("ground")))
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }


}
