using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionStatus : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField]
    int initialInfectionLevel = 0;

    [Header("State")]

    [ReadOnly]
    [SerializeField]
    int infectionLevel;

    private void Start()
    {
        infectionLevel = initialInfectionLevel;
    }
}