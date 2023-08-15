using System;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;

    public float maximunLife = 100f;
    
    public UnityEvent onDeath;

    public float Amount
    {
        get => amount;
        set
        {
            amount = value;
            
            if (amount <= 0)
            {
                onDeath.Invoke();
            }
        }
    }

    private void Awake()
    {
        amount = maximunLife;
    }
}
