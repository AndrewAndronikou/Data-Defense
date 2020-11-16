using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;
   // public int range;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
