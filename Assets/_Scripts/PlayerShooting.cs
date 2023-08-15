using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shootingPoint;
    private Animator _animator;
    public int bulletsAmount;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            _animator.SetTrigger("Shot Bullet");
            
            Invoke("FireBullet", 0.4f);
        }
    }

    void FireBullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("Player Bullet");
        bullet.transform.position = shootingPoint.transform.position;
        bullet.transform.rotation = shootingPoint.transform.rotation;
        bullet.SetActive(true);
        
        bulletsAmount--;
    }
}
