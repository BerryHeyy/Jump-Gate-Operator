using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrimeStat 
{
    public static readonly CrimeStat CLEAN = new CrimeStat("Clean", 0);
    public static readonly CrimeStat PETTY_CRIMINAL = new CrimeStat("Petty Criminal", 1000);
    public static readonly CrimeStat CRIMINAL = new CrimeStat("Criminal", 5000);
    public static readonly CrimeStat DANGEROUS_CRIMINAL = new CrimeStat("Dangerous Criminal", 10000);
    public static readonly CrimeStat DEADLY = new CrimeStat("Deadly", 20000);

    public string Name { get; private set; }
    public int Fine { get; private set; }

    CrimeStat(string name, int fine) =>
        (Name, Fine) = (name, fine);

    public static IEnumerable<CrimeStat> Values {
        get {
            yield return CLEAN;
            yield return PETTY_CRIMINAL;
            yield return CRIMINAL;
            yield return DANGEROUS_CRIMINAL;
            yield return DEADLY;
        }
    }

}
