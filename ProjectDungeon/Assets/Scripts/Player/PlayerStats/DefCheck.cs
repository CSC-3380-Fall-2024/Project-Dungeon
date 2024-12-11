using UnityEngine;
using JetBrains.Annotations;

public class DefCheck 
{
    //public static double DRDefense; // Defense that will be used to find Damage reduction
    public double DefReduction;

    public double DamageReduction(double DRDefense)
    {
        if (DRDefense < 2) // when defense is less than 2, there will be no damage reduction
        {
            DefReduction = 1;
        }
        else if (DRDefense >= 2 && DRDefense < 4) // when  def is 2-3, applies 20% damage reduction (will multiply at end of damage calc)
        {
            DefReduction = 0.80;
        }
        else if (DRDefense >= 4 && DRDefense < 6) // when  def is 4-5, applies 30% damage reduction
        {
            DefReduction = 0.70;
        }
        else if (DRDefense >= 6 && DRDefense < 8) // when  def is 6-7, applies 40% damage reduction
        {
            DefReduction = 0.60;
        }
        else if (DRDefense >= 8) // when  def is 8 or higher, applies 50% damage reduction
        {
            DefReduction = 0.50;
        }
        return DefReduction;
    }
}
