using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardFX : MonoBehaviour
{
    [SerializeField] Transform cameraToLookAt;

    private void Update()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
    }
}
