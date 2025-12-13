using UnityEngine;

public class SimpleTarget : MonoBehaviour
{
    
    [SerializeField] private int maxHP = 3;

    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    //Aqui te dejo como se le deberia hablar a la funcion Hyan

    /*
    if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, range))
    {
          Target target = hit.collider.GetComponent<Target>();
          if (target != null)
          {
                target.TakeDamage();
          }
    
    }
    */
    public void TakeDamage()
    {
        
        currentHP--;               
        Debug.Log($"Target Hit! HP Left: {currentHP}");

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
