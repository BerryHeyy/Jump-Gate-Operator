using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpgateAnimation : MonoBehaviour
{

    public float rotationRate = 0.1f;

    Jumpgate jumpgate;



    void Start()
    {
        jumpgate = GetComponent<Jumpgate>();
    }

    void LateUpdate()
    {
        if (jumpgate.Active)
        {
            ActiveAnimations();
        }
    }

    void ActiveAnimations()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationRate * Time.deltaTime));
    }

    
}
