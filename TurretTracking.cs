using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://www.youtube.com/watch?v=-_k8Ob7ElUo */

public class TurretTracking : MonoBehaviour {

    public float speed = 3.0f;
    public GameObject p_target = null;
    Vector3 p_lastKnownPosition = Vector3.zero;
    Quaternion p_lookAtRotation;

	// Use this for initialization
	void Start () {
		
	}
	
    /************************************
     * Update()
     *  Targets players current position
    **************************************/
void Update () {

        if (p_target)
        {
            // If the player has moved, calculate new location
            if (p_lastKnownPosition != p_target.transform.position)
            {
                p_lastKnownPosition = p_target.transform.position;
                p_lookAtRotation = Quaternion.LookRotation(p_lastKnownPosition - transform.position);
            }

            // If not already looking at player, look at new location
            if (transform.rotation != p_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, p_lookAtRotation, speed * Time.deltaTime);
            }
        }
	}

    // Validate target. Set Value.
    bool SetTarget(GameObject target)
    {
        if(target)
        {
            return false;
        }

        p_target = target;

        return true;
    }
}
