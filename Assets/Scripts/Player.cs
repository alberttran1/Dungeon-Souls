using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int playerSpeed = 5;
    public Animator animator;


    private Vector3 facing;
    private bool rolling = false;
    public int rollSpeed = 9;
    private Vector3 moveVector;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manageMovement();
    }

    void faceDirection()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = 10;
            transform.localScale = temp;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = -10;
            transform.localScale = temp;
        }
    }

    void manageMovement()
    {
        if (Input.GetMouseButtonDown(1) & !rolling)
        {
            animator.SetBool("Rolling", true);
            startRoll();
        }
        if (rolling)
        {
            transform.position += moveVector * Time.deltaTime;
        }
        else
        {
            faceDirection();
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
            if ((horizontal + vertical).magnitude > 0)
            {
                facing = (horizontal + vertical);
                facing.Normalize();
            }
            moveVector = (horizontal + vertical);
            moveVector.Normalize();
            moveVector *= Time.deltaTime * playerSpeed;
            transform.position += moveVector;
            animator.SetFloat("Speed", moveVector.magnitude);
        }
    }

    void startRoll()
    {
        rolling = true;
        moveVector = facing;
        moveVector *= rollSpeed;
    }
    void endRoll()
    {
        animator.SetBool("Rolling", false);
        rolling = false;
    }

}
