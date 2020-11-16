using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretCapacityUI : MonoBehaviour
{
    [SerializeField] Text turretCapacityText;

    // Update is called once per frame
    void Update()
    {
        turretCapacityText.text = PlayerStats.BuildAmount.ToString() + "/" + PlayerStats.BuildCapacity.ToString();
    }
}
