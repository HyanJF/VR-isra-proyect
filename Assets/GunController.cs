using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    [Header("Ajustes de Disparo")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;

    [Header("Balas")]
    public int maxAmmo = 12;
    private int currentAmmo;

    [Header("UI")]
    public TextMeshPro ammoText;

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    public void Shoot()
    {
        if (currentAmmo <= 0)
            return;

        GameObject b = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.linearVelocity = shootPoint.forward * bulletSpeed;

        currentAmmo--;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        if (ammoText != null)
            ammoText.text = currentAmmo.ToString();
    }
}
