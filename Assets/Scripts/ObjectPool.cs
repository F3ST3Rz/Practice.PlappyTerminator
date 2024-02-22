using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KillScore))]
public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Robot _prefab;

    private Queue<Robot> _pool;
    private KillScore _scoreCounter;

    public IEnumerable<Robot> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Robot>();
        _scoreCounter = GetComponent<KillScore>();
    }

    public Robot GetObject()
    {
        if (_pool.Count == 0)
        {
            var robot = Instantiate(_prefab);
            robot.transform.parent = _container;

            return robot;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Robot robot)
    {
        _pool.Enqueue(robot);
        robot.gameObject.SetActive(false);
    }

    public void PutObjectDiscoveredByBullet(Robot robot)
    {
        PutObject(robot);
        _scoreCounter.Add();
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
