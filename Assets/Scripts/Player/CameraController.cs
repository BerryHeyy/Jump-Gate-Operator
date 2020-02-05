using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Material skyBoxMaterial;

    private float xRotation = 0f;

    private Transform player;
    private GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        UI = GameObject.Find("UI");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);

        }
    }

    public void ChangeSkyboxRotation(float x, float y, float z)
    {

        skyBoxMaterial.SetFloat("_RotationX", skyBoxMaterial.GetFloat("_RotationX") + x);
        skyBoxMaterial.SetFloat("_RotationY", skyBoxMaterial.GetFloat("_RotationY") + y);
        skyBoxMaterial.SetFloat("_RotationZ", skyBoxMaterial.GetFloat("_RotationZ") + z);

    }

    
}
