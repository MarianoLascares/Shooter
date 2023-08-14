using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance; //Singleton
    
    [SerializeField]
    [Tooltip("Cantidad de puntos de la partida actual")]
    private int amount;

    public int Amount
    {
        get => amount; 
        set => amount = value;
    }
    
    private void Awake()
    {
        #region Singleton
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.Log("ScoreManager duplicado debe ser destruido", gameObject);
            Destroy(gameObject);
        }
        #endregion
        
    }
}
