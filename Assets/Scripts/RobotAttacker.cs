using System.Collections;
using UnityEngine;

public class RobotAttacker : Attacker
{
    [SerializeField] private float _timePeriodicShoot;

    private void OnEnable()
    {
        StartCoroutine(StartShoot());
    }

    private IEnumerator StartShoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_timePeriodicShoot);

        while (enabled)
        {
            yield return wait;
            Shoot();
        }
    }
}
