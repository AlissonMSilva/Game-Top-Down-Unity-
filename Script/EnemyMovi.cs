using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovi : MonoBehaviour
{
    public Transform[] point;
    public int speed, pointNum;
    Rigidbody2D r2D;
    Transform player;
    public Transform topTank;
    // Animator anim;
    [Header("Life")]
    public Image life;
    public float lifeValue;
    public float lifeMax = 100;
    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
        r2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        lifeValue = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        life.fillAmount = lifeValue / lifeMax;
        LifeColor();
        if (Vector3.Distance(transform.position, player.position) > 8)
        {
            // anim.Play("Walk");
            transform.localPosition = Vector3.MoveTowards(transform.position, point[pointNum].position, step);
            Vector3 lookPos = point[pointNum].position;
            Vector2 direction = new Vector2(lookPos.x - transform.position.x, lookPos.y - transform.position.y);
            transform.up = direction;
        }
        else
        {
            // anim.Play("Idle");
        }
        if (Vector3.Distance(transform.position, point[pointNum].position) < 0.01f)
        {
            pointNum++;
        }
        if (pointNum >= point.Length)
        {
            pointNum = 0;
        }
        if (lifeValue <= 0)
        {
            lifeValue = 0;
            // anim.Play("Idle");
            this.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "TankBullet(Clone)")
        {
            Destroy(other.gameObject);
            Damage(25);
        }
    }
    void LifeColor()
    {
        if (lifeValue > 80)
        {
            life.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        }
        if (lifeValue <= 50)
        {
            life.GetComponent<Image>().color = new Color(255, 255, 0, 255);
        }
        if (lifeValue <= 25)
        {
            life.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }
    float Damage(float dmg)
    {
        lifeValue -= dmg;
        return lifeValue;
    }
}
