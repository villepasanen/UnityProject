using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float _dps;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.LoseHealth(Time.fixedDeltaTime * _dps);
        }
    }
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
