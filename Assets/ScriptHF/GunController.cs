using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;

    [Header("Balas")]
    public int maxAmmo = 12;
    public int currentAmmo;

    [Header("UI")]
    public TextMeshPro ammoText;

    [Header("Bolt")]
    public Animator boltAnimator;
    public string boltEmptyBool = "Descargar";

    private bool isEmpty = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    public void Shoot()
    {
        if (isEmpty || currentAmmo <= 0)
            return;

        GameObject b = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.linearVelocity = shootPoint.forward * bulletSpeed;

        currentAmmo--;
        UpdateAmmoText();

        if (currentAmmo <= 0)
        {
            EmptyGun();
        }
    }

    private void EmptyGun()
    {
        isEmpty = true;
        boltAnimator.SetBool(boltEmptyBool, true);
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        isEmpty = false;
        boltAnimator.SetBool(boltEmptyBool, false);
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        if (ammoText == null) return;

        ammoText.text = currentAmmo + " / " + maxAmmo;
        ammoText.color = currentAmmo == 0 ? Color.red : Color.white;
    }
}
