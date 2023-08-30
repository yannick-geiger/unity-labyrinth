using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSchiebekarte : MonoBehaviour
{
    [SerializeField]
    private GameObject Schiebekarte;

    public void TurnSchiebekarte()
    {
        Schiebekarte.transform.Rotate(0f, 0f, 90f);
    }
}
