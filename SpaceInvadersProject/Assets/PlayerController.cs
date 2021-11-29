using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform bullet_spawn;
    public GameObject bullet;

    private Rigidbody rigid_body;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if (Input.GetButtonDown("Fire1")) {
            fireBullet();
        }
    }

    void movePlayer() {
        float x_movement = Input.GetAxis("Horizontal") * speed;
        Vector3 movement_vector = new Vector3(x_movement, 0);
        rigid_body.velocity = movement_vector;
    }

    void fireBullet() {
        Instantiate(bullet, bullet_spawn);
    }
}
