using UnityEngine;

public class SimpleCarpet : Carpet
{
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
        takeWindow.SetActive(false);
        sceneTraining.SetActive(true);
    }
}
