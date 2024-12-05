using UnityEngine;

public class Pet : MonoBehaviour
{
    public static Pet Instance;

    [SerializeField] private PetMove petMove;
    [SerializeField] private GameObject[] petBodys;

    private Animator animator;

    public float mulptiplierPet = 1;
    public bool isTake = false;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPet(int id)
    {
        DiactivePet();
        petBodys[id].SetActive(true);
        petMove.animator = petBodys[id].GetComponent<Animator>();
        isTake = true;
    }

    public void DiactivePet()
    {
        for (int i = 0; i < petBodys.Length; i++)
        {
            petBodys[i].SetActive(false);
        }
    }
}
