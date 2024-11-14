using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public int damageAmount = 10; 
    public Transform player; 

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        Debug.Log("Player Found");
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
