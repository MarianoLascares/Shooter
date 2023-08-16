using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Cantidad de puntos obtenidos al derrotar un enemigo")]
    public int pointsAmount = 100;

    private void Awake()
    {
        Life life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
    }

    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }

    private void DestroyEnemy()
    {
        Invoke("PlayDestruction", 0);
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");
        Destroy(gameObject, 1.5f);
        
        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }

    private void OnDestroy()
    {
        Life life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);
    }

    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}
