using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, turnSpeed;
    Rigidbody2D rb2D;
    Animator anim;
    public Transform rotationPoint;
    public float rotationTank;

    [Header("Ammo")]
    public GameObject shoot;
    public Transform pointShoot;
    public float timeShoot, timeNextShoot;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update() 
    {
        if (Input.GetButtonDown("Fire1") && timeNextShoot < Time.time)
        {
            Shoot();
            timeNextShoot = Time.time + timeShoot;
        }
    }
    void FixedUpdate()
    {
        float inputV = Input.GetAxisRaw("Vertical");// w=1 s=-1
        float inputH = Input.GetAxisRaw("Horizontal");//d=1 a=-1
        transform.localPosition += transform.up * speed * inputV * Time.deltaTime; 
        rotationTank -= inputH;
        transform.localRotation = Quaternion.Euler(0, 0, rotationTank * turnSpeed * Time.deltaTime);
        if (inputV > 0)
        {
            anim.Play("TankWalk");
        }
        else if (inputV < 0)
        {
            anim.Play("TankWalkBack");
        }
        else
        {
            anim.Play("TankIdle");
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(shoot, pointShoot.position, rotationPoint.localRotation);
    }

}