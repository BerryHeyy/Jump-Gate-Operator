using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpgateAnimation : MonoBehaviour
{

    public float rotationRate = 0.1f;

    Jumpgate jumpgate;

    public bool JumpInProgress { get; set; }

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
        if (JumpInProgress)
        {
            if (!jumpgate.ship.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ShipJumpAnimation"))
            {
                // Play all jump effects
                EndJumpEffects();
                JumpInProgress = false;
                // Invoke the OnJump() event
                GameObject.Find("EventManager").GetComponent<EventManager>().InvokeOnJump();
            }
        }
    }

    void ActiveAnimations()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationRate * Time.deltaTime));
    }

    void EndJumpEffects()
    {

    }

    
}
