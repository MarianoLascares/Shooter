using System;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayers;
    public LayerMask obstacleLayers;

    public Collider detectedTarget;
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, targetLayers);

        detectedTarget = null;
        
        foreach (Collider collider in colliders)
        {
            //Vision del enemigo con donde está ubicado el player
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);

            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider); //Angulo que forma el vector vision con el vector objetivo

            if (angleToCollider < angle) //Si el angulo es menor que el de la vision
            {
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstacleLayers)) //si no hay un objeto en medio
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedTarget = collider; //guardamos referencia del objetivo detectado
                    break;
                }
                else //hay hit
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.magenta;
        Vector3 rightDir = Quaternion.Euler(0, angle, 0)*transform.forward;
        Gizmos.DrawRay(transform.position, rightDir*distance);
        
        Vector3 leftDir = Quaternion.Euler(0, -angle, 0)*transform.forward;
        Gizmos.DrawRay(transform.position, leftDir*distance);
        
    }
}
