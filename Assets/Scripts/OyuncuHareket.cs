using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{

    public GameObject groundChecker;
    [HideInInspector]
    public CharacterController control;

    public float gravity = -9.81f;
    public float hiz = 10f;
    public float groundCheckSize = 0.4f;
    public float jHeight = 4f;


    public LayerMask groundMask;

    //------------Privates-------------
    Vector3 gravityVelocity;
    bool isGrounded;

    //-------------------------
    // Start is called before the first frame update
    void Start()
    {
      control = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.transform.position, groundCheckSize, groundMask);

        if (isGrounded && gravityVelocity.y <0)
        {
            gravityVelocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mov = transform.right * x + transform.forward * z;


        control.Move(mov * hiz * Time.deltaTime);

        gravityVelocity.y += gravity * Time.deltaTime;

        control.Move(gravityVelocity * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVelocity.y = Mathf.Sqrt(jHeight * -2f * gravity);
        }


    }
}
