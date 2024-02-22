using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _poolSize;

    private List<Bullet> _pool;

    private void Start()
    {
        _pool = new List<Bullet>();

        for (int i = 0; i < _poolSize; i++)
        {
            AddObject();
        }
    }

    public Bullet GetObject()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].gameObject.activeInHierarchy)
            {
                return _pool[i];
            }
        }

        return AddObject();
    }

    private Bullet AddObject()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.gameObject.SetActive(false);
        _pool.Add(bullet);
        return bullet;
    }

    private void OnDestroy()
    {
        foreach (var pool in _pool)
        {
            Destroy(pool.gameObject);
        }
    }
}
