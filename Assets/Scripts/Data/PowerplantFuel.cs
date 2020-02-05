using UnityEngine;
using System.Collections;

public class PowerplantFuel
{

    public float amount;
    public float maxAmount;
    public PowerplantFuelType powerplantFuelType;

    public PowerplantFuel(PowerplantFuelType powerplantFuelType)
    {
        this.amount = 2000f;
        this.maxAmount = 2000f;
        this.powerplantFuelType = powerplantFuelType;
    }

    public bool useFuel(float amount)
    {
        float toUseFuel = amount * powerplantFuelType.Efficiency;

        if (this.amount - toUseFuel < 0) return false;

        this.amount -= toUseFuel;
        return true;
    }

    public bool addFuel(float amount)
    { 
        if (this.amount + amount < this.maxAmount) return false;

        this.amount += amount;
        return true;
    }

}
