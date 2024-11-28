using UnityEngine;
using JetBrains.Annotations;
using UnityEngine;

public class DefCheck : MonoBehaviour
{
    public static double DRDefense; // Defense that will be used to find Damage reduction
    public double DefReduction;

    public double DamageReduction(double DRDefense)
    {
        if (DRDefense < 5) // when defense is less than 5, there will be no damage reduction
        {
            DefReduction = 1;
        }
        else if (DRDefense >= 5 && DRDefense < 10) // when player's def is 5-9, applies 20% damage reduction (will multiply at end of damage calc)
        {
            DefReduction = 0.80;
        }
        else if (DRDefense >= 10 && DRDefense < 15) // when player's def is 10-14, applies 30% damage reduction
        {
            DefReduction = 0.70;
        }
        else if (DRDefense >= 15 && DRDefense < 20) // when player's def is 15-19, applies 40% damage reduction
        {
            DefReduction = 0.60;
        }
        else if (DRDefense >= 20) // when player's def is 20 or higher, applies 50% damage reduction
        {
            DefReduction = 0.50;
        }
        return DefReduction;
    }
}
