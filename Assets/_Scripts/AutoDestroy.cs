using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Tooltip("Tiempo después del cual se destruye el objeto")]
    public float delay;
    
    void OnEnable()
    {  
        //Destroy(gameObject, delay);
        Invoke("HideObject", delay);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}
