using UnityEngine;

public class JumpScript : MonoBehaviour
{
    //Variable
    Rigidbody rig;
    public float speed = 10f;
    bool jumping;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            jumping = true;
    }

    private void FixedUpdate()
    {
        // Rigidbody needs to be coded
       if (jumping)
       {
            rig.AddForce(transform.up * speed, ForceMode.VelocityChange);
            isGrounded = false;
            jumping = false;
       }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
