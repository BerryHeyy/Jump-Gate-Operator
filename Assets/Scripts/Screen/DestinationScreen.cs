using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestinationScreen : MonoBehaviour
{

    public JumpgateController jumpgateController;
    JumpgateHandler jumpgate;

    public TextMeshProUGUI destinationValue;
    public TextMeshProUGUI distanceValue;
    public TextMeshProUGUI fuelValue;
    public TextMeshProUGUI targetDeviationValue;
    public TextMeshProUGUI yawValue;
    public TextMeshProUGUI pitchValue;

    public Image yawCheck;
    public Image pitchCheck;

    public Sprite cross;
    public Sprite check;
    public Sprite dash;

    bool activeShip;

    void OnEnable()
    {
        EventManager.OnArrive += OnShipArrived;
        EventManager.OnJump += OnShipJumped;
    }

    void OnDisable()
    {
        EventManager.OnArrive -= OnShipArrived;
        EventManager.OnJump -= OnShipJumped;
    }

    void Start()
    {
        jumpgate = jumpgateController.gameObject.GetComponent<JumpgateHandler>();
    }

    void Update()
    {
        if (activeShip)
        {
            UpdateDeviations();
        }
    }

    public void OnShipArrived(Ship ship)
    {
        activeShip = true;
        destinationValue.SetText(ship.destination.name);
        distanceValue.SetText(ship.destination.distance + " ly");
        fuelValue.SetText(ship.destination.fuel + " tonnes");
        targetDeviationValue.SetText(ship.destination.yaw + "° yaw / " + ship.destination.pitch + "° pitch");
    }

    public void OnShipJumped()
    {
        destinationValue.SetText("Ship not found");
        distanceValue.SetText("Ship not found");
        fuelValue.SetText("Ship not found");
        targetDeviationValue.SetText("Ship not found");
        yawCheck.sprite = dash;
        pitchCheck.sprite = dash;
        activeShip = false;
    }

    void UpdateDeviations()
    {
        yawValue.SetText((int) jumpgateController.Yaw + "°");
        pitchValue.SetText((int) jumpgateController.Pitch + "°");

        if (jumpgate.IsYawAligned()) yawCheck.sprite = check;
        else yawCheck.sprite = cross;
        if (jumpgate.IsPitchAligned()) pitchCheck.sprite = check;
        else pitchCheck.sprite = cross;
    }

}
