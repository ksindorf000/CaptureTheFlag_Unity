using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://www.youtube.com/watch?v=nHS83vVRBWE */
// The base class for all projectiles

public abstract class BaseProjectile : MonoBehaviour {

    public float speed = 5;
    public abstract void ShootArrow(GameObject fireFrom, GameObject target, int damage);
}
