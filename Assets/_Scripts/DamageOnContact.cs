using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        
        /*if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }*/

        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            life.Amount -= damage; // life!.amount = damage; es lo mismo
        }
        
    }
}
