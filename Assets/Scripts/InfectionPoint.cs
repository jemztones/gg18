using UnityEngine;

public class InfectionPoint : MonoBehaviour
{
	[SerializeField]
	int infectionAmount;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("i'm infected");
		other.gameObject.GetComponent<InfectionStatus>().IncreaseInfectionLevel(infectionAmount);
    }
}
