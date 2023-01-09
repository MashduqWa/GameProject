using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;

    private FixedJoystick joystick;
    private PlayerAnimator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        anim = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

        if(joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            anim.Running(true);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            anim.Running(false);
        }
    }
}
