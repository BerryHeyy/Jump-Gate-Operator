using UnityEngine;
using System.Collections;

public class Jumpgate : MonoBehaviour
{

    public Ship ship;
    public Fuel fuel;

    EventManager eventManager;

    void OnEnable()
    {
        EventManager.OnJump += Jump;
    }

    void OnDisable()
    {

    }

    void Start()
    {
        fuel = new Fuel("Exotic Matter")
        {
            amount = 1000
        };

        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }

    void Update()
    {

    }

    public bool HasShip()
    {
        return ship != null;
    }

    public bool CanJump()
    {
        if (!HasShip()) return false;
        if (!ship.locked) return false;
        if (!IsCorrectlyAligned()) return false;
        return true;
    }

    public void ShipArrived(Ship ship)
    {
        this.ship = ship;
        eventManager.InvokeOnArrive(ship);
    }

    public void Jump()
    {
        fuel.ChangeAmount(-ship.mass);
        ship.Jump();
        ship = null;
    }

    public bool IsYawAligned()
    {
        if (!HasShip()) return false;
        return (int) GetComponent<JumpgateController>().yaw == (int) ship.destination.yaw;
    }

    public bool IsPitchAligned()
    {
        if (!HasShip()) return false;
        return (int) GetComponent<JumpgateController>().pitch == (int) ship.destination.pitch;
    }

    public bool IsCorrectlyAligned()
    {
        return IsYawAligned() && IsPitchAligned();
    }

}
