using System.Collections;
using UnityEngine;

public class FpsLocker : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(ShowFPS());
    }

    private IEnumerator ShowFPS()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log(1 / Time.deltaTime);
        }
    }
}
