using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    [Header("Disparo")]
    public Transform shootPoint;
    public float range = 100f;
    public LayerMask hitLayers;

    [Header("Balas")]
    public int maxAmmo = 99;
    public int currentAmmo;

    [Header("UI")]
    public TextMeshPro ammoText;

    [Header("Bolt")]
    public Animator boltAnimator;
    public string boltEmptyBool = "descargar";

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

        currentAmmo--;
        UpdateAmmoText();

        RaycastHit hit;

        Debug.DrawRay(
            shootPoint.position,
            shootPoint.forward * range,
            Color.red,
            1f
        );

        if (Physics.Raycast(
            shootPoint.position,
            shootPoint.forward,
            out hit,
            range,
            hitLayers))
        {
            HandleHit(hit.collider);
        }

        if (currentAmmo <= 0)
            EmptyGun();
    }

    private void HandleHit(Collider other)
    {
        DummyAccuracyManager accuracyManager =
            other.GetComponentInParent<DummyAccuracyManager>();

        if (accuracyManager != null)
        {
            accuracyManager.RegisterHit();
        }

        TargetMoving movingTarget =
            other.GetComponentInParent<TargetMoving>();

        if (movingTarget != null)
        {
            movingTarget.TakeDamage();
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
