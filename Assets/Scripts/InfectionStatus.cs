using UnityEngine;
using UnityEngine.Events;

public class InfectionStatus : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField]
    int initialInfectionLevel = 0;

    [SerializeField]
    int deathLevel;

	public InfectionChangeEvent infectionChangeEvent;

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
		infectionChangeEvent.Invoke (infectionLevel);
        if(infectionLevel >= deathLevel)
        {
            Debug.Log("*dark souls voice* u died");
        }
    }
}

[System.Serializable]
public class InfectionChangeEvent : UnityEvent<int>
{
}