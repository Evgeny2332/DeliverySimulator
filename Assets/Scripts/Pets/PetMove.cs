using UnityEngine;

public class PetMove : MonoBehaviour
{
    [SerializeField] private Pet pet;

    [SerializeField] private Transform target;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    public Animator animator;

    private void Update()
    {
        if (pet.isTake)
        {
            Vector3 direction = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z).normalized;

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            if (distanceToTarget > 0.15f)
            {
                transform.position += direction * speed * Time.deltaTime;
                animator.SetBool("isMove", true);
            }
            else
            {
                animator.SetBool("isMove", false);
            }
        }     
    }


}