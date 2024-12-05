using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private WalletManager walletManager;
    [SerializeField] private PlayerInteractive playerInteractive;

    [SerializeField] private GameObject[] boxes;
    [SerializeField] private int[] rewardForBox;

    [SerializeField] private float multiplierPet = 1;

    public int idBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInteractive.isTakeBox)
        {
            boxes[idBox].SetActive(false);
            multiplierPet = Pet.Instance.mulptiplierPet;
            walletManager.Energy += rewardForBox[idBox] * multiplierPet;
            playerInteractive.isTakeBox = false;
        }
    }
}
