using UnityEngine;

public class CyberManAttacker : Attacker
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }
}
