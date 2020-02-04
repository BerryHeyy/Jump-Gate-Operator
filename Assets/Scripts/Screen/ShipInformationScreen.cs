using UnityEngine;
using System.Collections;
using TMPro;

public class ShipInformationScreen : MonoBehaviour
{

    public TextMeshProUGUI shipTypeValue;
    public TextMeshProUGUI gaLIDValue;
    public TextMeshProUGUI crimeStatValue;

    Jumpgate jumpgate;

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
        jumpgate = GameObject.Find("Jumpgate").GetComponent<Jumpgate>();
    }

    void Update()
    {

    }

    void OnShipArrived(Ship ship)
    {
        shipTypeValue.SetText(ship.shipType.manufacturer.ToString() + " " + ship.shipType.model);
        gaLIDValue.SetText(ship.shipType.manufacturer.ToString() + "-" + ship.gaLID);
        crimeStatValue.SetText(ship.crimeStat.Name);
    }

    void OnShipJumped()
    {

    }
}
