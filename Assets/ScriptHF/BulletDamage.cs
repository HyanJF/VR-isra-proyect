using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("RangeTarget"))
        {
            //Aqui va la llamada a la funcion para detectar que el jugador le atino al Dummy del Firing Range
            DummyAccuracyManager AccuracyManager = other.GetComponentInParent<DummyAccuracyManager>();
            AccuracyManager.RegisterHit();
            Destroy(gameObject);
            return;
        }

        if (!other.CompareTag("Dummies"))
            return;

        TargetMoving movingTarget = other.GetComponentInParent<TargetMoving>();
        if (movingTarget != null)
        {
            movingTarget.TakeDamage();
            Destroy(gameObject);
            return;
        }
    }
}
