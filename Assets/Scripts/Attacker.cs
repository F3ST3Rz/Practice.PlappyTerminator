using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private const string Attack = nameof(Attack);

    [SerializeField] private Animator _animator;
    [SerializeField] private BulletPool _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _speedShot;

    protected void Shoot()
    {
        _animator.SetTrigger(Attack);
        var bullet = _bullet.GetObject();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = transform.rotation;
        int direction = (transform.localScale.x >= 0) ? 1 : -1;
        bullet.gameObject.GetComponent<Bullet>().ChangeShot(_speedShot, direction);
    }
}
