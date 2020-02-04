using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public Destination destination;
    public CrimeStat crimeStat;
    public ShipType shipType;

    public int gaLID;
    public int mass;
    public bool locked;

    private bool instantiated = false;

    void Start()
    {
        destination = new Destination
        {
            name = "Chronus",
            pitch = -70f,
            yaw = 60f,
            distance = 35,
            fuel = 500
        };

        shipType = new ShipType(ShipType.Manufacturer.CenterPoint, "CP3002");

        gaLID = Random.Range(1000000, 9999999);
        mass = 500;
        locked = false;

        crimeStat = CrimeStat.DEADLY;


    }

    void Update()
    {
        // Set jumpgate ship to this
        if (!instantiated)
        {
            GameObject.Find("Jumpgate").GetComponent<Jumpgate>().ShipArrived(this);
            instantiated = true;
        }

    }

    public void Jump()
    {
        Destroy(gameObject);
        Destroy(this);
    }

}
