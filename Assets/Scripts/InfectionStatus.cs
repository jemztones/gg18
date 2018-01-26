using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionStatus : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField]
    int initialInfectionLevel = 0;

    [SerializeField]
    int deathLevel;

    [Header("State")]

    [ReadOnly]
    [SerializeField]
    int infectionLevel;

    private void Start()
    {
        infectionLevel = initialInfectionLevel;
    }

    public void IncreaseInfectionLevel(int amount)
    {
        infectionLevel = infectionLevel + amount;
        if(infectionLevel >= deathLevel)
        {
            Debug.Log("*dark souls voice* u died");
        }
    }
}