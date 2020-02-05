using UnityEngine;
using System.Collections;

public class Jumpgate : MonoBehaviour
{

    // Position
    public float yaw, pitch;
    // Jump
    public bool canJump;
    // Fuel
    JumpgateFuel jumpgateFuel;
    // Powerplant
    Powerplant powerplant;
    // Components
    GravityGenerator gravityGenerator;
    OxygenGenerator oxygenGenerator;
    WarrantScanner warrantScanner;
    IntegrityScanner integrityScanner;
    DiagnosticsScanner diagnosticsScanner;

    TractorBeam tractorBeam;

    void Start()
    {
        // Initialize components
        gravityGenerator = gameObject.AddComponent<GravityGenerator>();
        oxygenGenerator = gameObject.AddComponent<OxygenGenerator>();
        warrantScanner = gameObject.AddComponent<WarrantScanner>();
        integrityScanner = gameObject.AddComponent<IntegrityScanner>();
        diagnosticsScanner = gameObject.AddComponent<DiagnosticsScanner>();

        tractorBeam = gameObject.AddComponent<TractorBeam>();
    }

}
