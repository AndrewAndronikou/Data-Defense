using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretInfoDisplay : MonoBehaviour
{
    [SerializeField] GameObject ui;

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
    }
}
