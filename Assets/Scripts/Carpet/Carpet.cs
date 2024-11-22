using UnityEngine;

public abstract class Carpet : MonoBehaviour
{
    [SerializeField] protected GameObject takeWindow;
    [SerializeField] protected GameObject sceneTraining;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerStay();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerExit();
        }
    }

    public abstract void TriggerStay();
    public abstract void TriggerExit();
}