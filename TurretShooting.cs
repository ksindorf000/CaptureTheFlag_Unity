using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://www.youtube.com/watch?v=Z8LxY8H4uY4 */
// Spawns and shoots projectiles

public class TurretShooting : MonoBehaviour
{

    public float fireRate;
    public float fieldOfView;
    public int damage;
    public GameObject arrow;
    public GameObject target;
    public List<GameObject> arrowSpawns;

    List<GameObject> lastArrows = new List<GameObject>();
    float fireTimer = 0.0f;
    
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
            if (angle > fieldOfView)
            {
                SpawnArrows();
                fireTimer = 0.0f;
            }
        }
    }

    void SpawnArrows()
    {
        if (!arrow)
        {
            for (int i = 0; i < arrowSpawns.Count; i++)
            {
                if (arrowSpawns[i])
                {
                    GameObject proj = Instantiate(arrow, arrowSpawns[i].transform.position, Quaternion.Euler(arrowSpawns[i].transform.forward)) as GameObject;
                    proj.GetComponent<BaseProjectile>().ShootArrow(arrowSpawns[i], target, damage);

                    lastArrows.Add(proj);
                }
            }
        }
    }
}
