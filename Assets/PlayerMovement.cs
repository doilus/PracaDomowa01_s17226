using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce;
    
    public float runSpeed;
    private float changeSpeed;
    private bool isRunning = false;

    public float dashSpeed;
    public float startDashTime;
    private float direction;
    private float dashTime;
    private Rigidbody2D rb;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        changeSpeed = speed;
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        //float xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x + xDisplacement,
        //                                transform.position.y,
        //                                0);
        float xDisplacement = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

        //run
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow))))
        {
            isRunning = true;
            speed = runSpeed;
        }
        else {
            isRunning = false;
            speed = changeSpeed;
        }

        //dash
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    direction = 1;
                }
                else if (Input.GetKey(KeyCode.RightArrow)) {
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    


}
