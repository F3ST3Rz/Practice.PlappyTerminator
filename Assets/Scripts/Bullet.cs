using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _timeBeforeDeactivate = 3f;

    private int _direction;
    private float _speedShot;

    private void OnEnable()
    {
        StartCoroutine(DeactivateObject());
    }

    private void Update()
    {
        transform.Translate(_direction * Vector2.right * _speedShot * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robot robot) && (gameObject.tag == robot.tag))
        {
            ObjectPool objectPool = robot.gameObject.GetComponentInParent<ObjectPool>();
            objectPool.PutObjectDiscoveredByBullet(robot);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(_timeBeforeDeactivate);
        gameObject.SetActive(false);
    }

    public void ChangeShot(float speedShot, int direction)
    {
        _direction = direction;
        _speedShot = speedShot;
    }
}
