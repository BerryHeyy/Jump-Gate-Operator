using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public JumpgateController jumpgateController;

    public float speed = 2f;
    public float gravity = -1.1f;
    public float jumpHeight = 30f;

    Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpgateController = GameObject.Find("Jumpgate").GetComponent<JumpgateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        if (controller.isGrounded && Input.GetButtonDown("Jump")) velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded) velocity.y = 0;
        controller.Move(velocity * Time.deltaTime);
        

        //transform.position += move * Time.deltaTime * speed;
        //transform.position += velocity * Time.deltaTime;


    }

    


}
