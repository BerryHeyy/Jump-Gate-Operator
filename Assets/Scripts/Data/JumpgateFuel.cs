using UnityEngine;
using System.Collections;

public class JumpgateFuel
{

    public float amount;
    public float maxAmount;
    public JumpgateFuelType jumpgateFuelType;

    public JumpgateFuel(JumpgateFuelType jumpgateFuelType)
    {
        this.amount = 2000f;
        this.maxAmount = 2000f;
        this.jumpgateFuelType = jumpgateFuelType;
    }

    public bool useFuel(float amount)
    {
        float toUseFuel = amount * jumpgateFuelType.Efficiency;

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
