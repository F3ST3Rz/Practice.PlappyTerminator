using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private void Update()
    {
        transform.Translate(-Vector2.right * _speedMove * Time.deltaTime);
    }
}
