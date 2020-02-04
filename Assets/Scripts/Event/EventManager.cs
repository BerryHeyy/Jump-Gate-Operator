using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void ShipJump();
    public static event ShipJump OnJump;

    public delegate void ShipArrival(Ship ship);
    public static event ShipArrival OnArrive;


    public void InvokeOnJump()
    {
        OnJump();
    }

    public void InvokeOnArrive(Ship ship)
    {
        OnArrive(ship);
    }

}
