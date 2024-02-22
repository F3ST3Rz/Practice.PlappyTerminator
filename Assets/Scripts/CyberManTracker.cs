using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberManTracker : MonoBehaviour
{
    [SerializeField] private CyberMan _cyberMan;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _cyberMan.transform.position.x + _xOffset;
        transform.position = position;
    }
}
