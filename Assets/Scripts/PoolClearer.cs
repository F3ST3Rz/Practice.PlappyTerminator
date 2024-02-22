using UnityEngine;

public class PoolClearer : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ObjectPool _pool;

    private Robot[] _robots;

    private void Add()
    {
        _robots = new Robot[_container.childCount];

        for (int i = 0; i < _container.childCount; i++)
        {
            _robots[i] = _container.GetChild(i).GetComponent<Robot>();
        }
    }

    public void Reset()
    {
        _pool.Reset();
        Add();

        foreach (var robot in _robots)
        {
            Destroy(robot.gameObject);
        }
    }
}