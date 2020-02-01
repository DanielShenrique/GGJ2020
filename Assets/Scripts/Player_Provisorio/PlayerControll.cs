using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private float speed;

    private Rigidbody2D rb;

    private GameObject enemy;

    private NPC1 npc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        npc = GameObject.FindGameObjectWithTag("NPC_1").GetComponent<NPC1>();
    }

    private void Start()
    {
        speed = 12f;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy"))
        {
            enemy = coll.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (enemy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(enemy);
                npc.numEnemiesDefeated++;
            }
        }
    }
}
