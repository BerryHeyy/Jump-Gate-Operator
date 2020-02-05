using UnityEngine;
using System.Collections;

public class JumpgateHandler : MonoBehaviour
{


    public Ship ship;
    public Fuel fuel;

    public bool Active { get; private set; }

    EventManager eventManager;
    JumpgateController jumpgateController;

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

        Active = false;

        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        jumpgateController = GetComponent<JumpgateController>();
    }

    void Update()
    {


    }

    public void OnActivateButton()
    {
        if (!Active) Active = true;
        else Active = false;
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
        if (!Active) return false;
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
        jumpgateController.DeactivateTractorBeams();
    }

    public bool IsYawAligned()
    {
        if (!HasShip()) return false;
        return (int) GetComponent<JumpgateController>().Yaw == (int) ship.destination.yaw;
    }

    public bool IsPitchAligned()
    {
        if (!HasShip()) return false;
        return (int) GetComponent<JumpgateController>().Pitch == (int) ship.destination.pitch;
    }

    public bool IsCorrectlyAligned()
    {
        return IsYawAligned() && IsPitchAligned();
    }

}
