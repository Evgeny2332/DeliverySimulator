using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private WalletManager walletManager;
    [SerializeField] private PlayerInteractive playerInteractive;

    [SerializeField] private GameObject[] boxes;
    [SerializeField] private int[] rewardForBox;

    public int idBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInteractive.isTakeBox)
        {
            boxes[idBox].SetActive(false);
            walletManager.Energy += rewardForBox[idBox];
            playerInteractive.isTakeBox = false;
        }
    }
}
