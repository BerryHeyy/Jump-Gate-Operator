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

    public bool changeAmount(float amount)
    {
        if (this.amount + amount > this.maxAmount) return false;
        if (this.amount + amount < 0) return false;

        this.amount += amount;
        return true;
    }
}
