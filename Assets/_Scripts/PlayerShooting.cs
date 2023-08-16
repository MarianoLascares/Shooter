using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Animator _animator;
    public int bulletsAmount;

    public Weapon weapon;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            if (bulletsAmount > 0 && weapon.ShootBullet("Player Bullet", 0.2f))
            {
                _animator.SetTrigger("Shoot Bullet");
                bulletsAmount--;
                if (bulletsAmount < 0)
                {
                    bulletsAmount = 0;
                }
            }
            else
            {
                //TODO: sonido de no tengo balas
            }
        }
    }

    void FireBullet()
    {
        
    }
}
