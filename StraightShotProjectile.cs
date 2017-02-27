using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://www.youtube.com/watch?v=nHS83vVRBWE */
// Shoots projectile from launcher toward player position

public class StraightShotProjectile : BaseProjectile {

    Vector3 direction;
    bool fired;
    
    private void Update()
    {
        if(fired)
        {
            transform.position += direction * (speed * Time.deltaTime);
        }
    }

    public override void ShootArrow(GameObject fireFrom, GameObject target, int damage)
    {
        if(fireFrom && target)
        {
            direction = (target.transform.position + fireFrom.transform.position).normalized;
            fired = true;
        }
    }

}
