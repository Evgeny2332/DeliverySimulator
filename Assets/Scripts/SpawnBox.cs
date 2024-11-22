using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] private PlayerInteractive playerInteractive;
    [SerializeField] protected Finish finish;
    [SerializeField] protected WalletManager walletManager;

    [SerializeField] private int idBox;
    [SerializeField] private int neededPower;
    [SerializeField] private GameObject takeWindow;
    [SerializeField] private GameObject box;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerInteractive.isTakeBox)
            {
                takeWindow.SetActive(true);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    TakeBox();
                }
            }
            else
                takeWindow.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            takeWindow.SetActive(false);
        }
    }

    public void TakeBox()
    {
        if (!playerInteractive.isTakeBox && walletManager.Power >= neededPower)
        {
            playerInteractive.isTakeBox = true;
            box.SetActive(true);
            finish.idBox = idBox;
        }
    }
}
