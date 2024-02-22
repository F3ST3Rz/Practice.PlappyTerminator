using System;
using UnityEngine;

[RequireComponent(typeof(CyberManCollisionHandler))]
[RequireComponent(typeof(CyberManMover))]
public class CyberMan : MonoBehaviour
{
    private CyberManCollisionHandler _handler;
    private CyberManMover _mover;

    public event Action GameOver;

    private void Awake()
    {
        _handler = GetComponent<CyberManCollisionHandler>();
        _mover = GetComponent<CyberManMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Robot or Cave or Bullet)
        {
            GameOver?.Invoke();
        }
    }

    public void Reset()
    {
        _mover.Reset();
    }
}
