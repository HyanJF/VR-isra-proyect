using UnityEngine;

public class Magazine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            GunController gun = other.GetComponentInChildren<GunController>();
            if (gun != null)
            {
                gun.Reload();
                Destroy(gameObject);
            }
        }
    }
}
