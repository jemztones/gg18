using UnityEngine;

public class InfectionPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("i'm infected");
        other.gameObject.GetComponent<InfectionStatus>().IncreaseInfectionLevel(10);
    }
}
