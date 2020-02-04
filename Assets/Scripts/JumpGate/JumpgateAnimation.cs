using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpgateAnimation : MonoBehaviour
{

    public float rotationRate = 0.1f;

    Jumpgate jumpgate;

    public bool JumpInProgress { get; set; }
    bool playerJumpEffects = false;
    int playerJumpEffectDuration = 3;

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
                playerJumpEffects = true;
            }
        }

        if (playerJumpEffects)
        {
            Image flashImage = GameObject.Find("UI").transform.GetChild(1).GetComponent<Image>();
            flashImage.color = new Vector4(1f, 1f, 1f, 1f);
            
            if (playerJumpEffectDuration > 0)
            {
                playerJumpEffectDuration--;
            } else
            {
                playerJumpEffectDuration = 3;
                playerJumpEffects = false;
            }


        } else
        {
            Image flashImage = GameObject.Find("UI").transform.GetChild(1).GetComponent<Image>();
            flashImage.color = new Vector4(1f, 1f, 1f, 0f);
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
