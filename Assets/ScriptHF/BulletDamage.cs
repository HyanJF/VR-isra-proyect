using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Dummies"))
            return;

        TargetMoving movingTarget = other.GetComponentInParent<TargetMoving>();
        if (movingTarget != null)
        {
            movingTarget.TakeDamage();
            Destroy(gameObject);
            return;
        }

        SimpleTarget simpleTarget = other.GetComponentInParent<SimpleTarget>();
        if (simpleTarget != null)
        {
            simpleTarget.TakeDamage();
            Destroy(gameObject);
            return;
        }
    }
}
