using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://www.youtube.com/watch?v=nHS83vVRBWE */
// Makes the projectile follow the target

public class TrackingProjectile : BaseProjectile
{

    GameObject t_target;

    void Update()
    {
        if (t_target)
        {
            transform.position = Vector3.MoveTowards(transform.position, t_target.transform.position, speed * Time.deltaTime);
        }
    }

    public override void ShootArrow(GameObject fireFrom, GameObject target, int damage)
    {
        if (target)
        {
            t_target = target;
        }
    }   

}
