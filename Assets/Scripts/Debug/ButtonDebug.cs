using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject); 
        }
    }
}
