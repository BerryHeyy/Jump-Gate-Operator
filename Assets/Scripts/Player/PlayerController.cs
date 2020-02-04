using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public CapsuleCollider collider;
    public JumpgateController jumpgateController;

    public float speed = 2f;
    public float gravity = -1.1f;
    public float jumpHeight = 30f;

    Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        jumpgateController = GameObject.Find("Jumpgate").GetComponent<JumpgateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        //if (isGrounded() && Input.GetButtonDown("Jump")) velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed);

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
        //if (isGrounded()) velocity.y = 0;

        transform.position += move * Time.deltaTime * speed;
        //transform.position += velocity * Time.deltaTime;


    }

    bool isGrounded()
    {
        return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.001f, collider.bounds.center.z), 0.5f);
    }


}
