using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipType
{

    public Manufacturer manufacturer;
    public string model;

    public ShipType(Manufacturer manu, string model)
    {
        this.manufacturer = manu;
        this.model = model;
    }

    public enum Manufacturer
    {
        CenterPoint,
        StingrayIntergalactic,
        BlueWhaleIndustrial,
        StantonSanction,
        EarthOrigin,
        FalconStandpoint
    }
}
