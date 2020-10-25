using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
    public float dashSpeed;
    public float startDashTime;
    private float direction;
    private float dashTime;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.LeftControl))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.LeftControl))
            {
                direction = 2;
            }
        }
        else {
            if (dashTime <= 0)
            {
                direction = 0;
            }
            else {
                dashTime -= Time.deltaTime;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2) {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
