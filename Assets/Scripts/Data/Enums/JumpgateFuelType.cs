using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpgateFuelType
{
    public static readonly JumpgateFuelType HYDROGEN = new JumpgateFuelType("Hydrogen", .5f, 1.5f);
    public static readonly JumpgateFuelType NITROGEN = new JumpgateFuelType("Nitrogen", 1f, 1f);

    public string Name { get; private set; }
    public float Efficiency { get; private set; }
    public float Boost { get; private set; }

    JumpgateFuelType(string name, float efficiency, float boost) =>
        (Name, Efficiency, Boost) = (name, efficiency, boost);

    public static IEnumerable<JumpgateFuelType> Values {
        get {
            yield return HYDROGEN;
            yield return NITROGEN;
        }
    }

}
