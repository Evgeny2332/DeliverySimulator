using UnityEngine;

public class FpsLocker : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}
