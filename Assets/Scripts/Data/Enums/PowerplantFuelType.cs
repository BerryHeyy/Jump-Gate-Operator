using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerplantFuelType
{
    public static readonly PowerplantFuelType HYDROGEN = new PowerplantFuelType("Hydrogen", 1f, 1000f  , PowerplantType.Fusion);
    public static readonly PowerplantFuelType URANIUM235 = new PowerplantFuelType("Uranium-235", .75f, 600f, PowerplantType.Fission);
    public static readonly PowerplantFuelType EXOTIC_MATTER = new PowerplantFuelType("Exotic Matter", .5f, 80600000f, PowerplantType.BlackHole);
    

    public string Name { get; private set; }
    public float Efficiency { get; private set; }
    public float Power { get; private set; }
    public PowerplantType PowerplantType { get; private set; }

    PowerplantFuelType(string name, float efficiency, float power, PowerplantType powerplantType) =>
        (Name, Efficiency, Power, PowerplantType) = (name, efficiency, power, powerplantType);

    public static IEnumerable<PowerplantFuelType> Values {
        get {
            yield return HYDROGEN;
            yield return URANIUM235;
            yield return EXOTIC_MATTER;
        }
    }

}
