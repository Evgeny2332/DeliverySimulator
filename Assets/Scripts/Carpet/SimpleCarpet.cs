using UnityEngine;

public class SimpleCarpet : Carpet
{
    [SerializeField] private PlayerInteractive playerInteractive;

    public override void TriggerStay()
    {
        takeWindow.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnTraining();
        }
    }

    public override void TriggerExit()
    {
        takeWindow.SetActive(false);
    }

    public void OnTraining()
    {
        if (!playerInteractive.isTakeBox)
        {
            takeWindow.SetActive(false);
            sceneTraining.SetActive(true);
        }
    }
}
