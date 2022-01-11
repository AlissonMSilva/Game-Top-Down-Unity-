using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{
    Transform player;
    Vector2 direction;
    public Transform baseTank, pointShoot;
    public GameObject shoot;
    public float timeShoot, timeNextShoot;
    EnemyMovi enemy;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        enemy = GetComponentInParent<EnemyMovi>();
    }
    void Update()
    {
        if (enemy.lifeValue > 0)
            if (Vector3.Distance(transform.position, player.position) < 8f)
            {
                Vector3 lookPos = player.position;
                direction = new Vector2(lookPos.x - transform.position.x, lookPos.y - transform.position.y);
                transform.up = direction;
                if (timeNextShoot < Time.time)
                {
                    Shoot();
                    timeNextShoot = Time.time + timeShoot;
                }
            }
            else
            {
                transform.up = baseTank.up;
            }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(shoot, pointShoot.position, pointShoot.rotation);
    }
}
