using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    

    [Header("HP Settings")]
    [SerializeField] private int maxHP = 3;
    private int currentHP;

    [Header("Movement Settings")]
    [SerializeField] private Transform[] waypoints;  
    [SerializeField] private float moveSpeed = 3f;   

    private int currentIndex = 0;     
    private int direction = 1;        

    
    private void Start()
    {
        currentHP = maxHP;

        
        if (waypoints == null || waypoints.Length < 2)
        {
            Debug.LogWarning("La diana necesita al menos 2 waypoints para moverse. Si fue intencional entonces jalo bien");
        }
    }

    // --------------------------------------------------------------
    private void Update()
    {
        MoveBetweenWaypoints();
    }

    
    private void MoveBetweenWaypoints()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        
        Transform target = waypoints[currentIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            
            currentIndex += direction;

            // Si llegamos al extremo superior, invertimos direccion
            if (currentIndex == waypoints.Length - 1)
            {
                direction = -1;
            }
            // Si llegamos al extremo inferior, invertimos direccion
            else if (currentIndex == 0)
            {
                direction = 1;
            }
        }
    }

    // Realisticamente, es mejor solo usar este script, porque funciona bien para los dos y asi no tienes que estar checando tanto si es un target simple
    // como si es un que se mueve. Si no quieres que se mueva solo no le pongas waypoints y jala igual, no deberia pasar nada malo

    //Aqui esta el ejemplo de como le podrias hablar Hyan

    // if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, range))
    // {
    //     TargetMoving movingTarget = hit.collider.GetComponent<TargetMoving>();
    //
    //     if (movingTarget != null)
    //     {

    //         movingTarget.TakeDamage();   
    //     }
    // }
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
