using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienScript : MonoBehaviour
{
    public float vertial_step = 1;
    //private float tolerance = 0.01f;
    public float horizontal_speed = 5;
    public float vertical_speed = -5;
    public float fire_delay = 1;
    public float bullet_speed = 5;
    public Transform fire_point;
    public GameObject bullet;
    public enum AlienState {horizontal_flight, vertical_flight };

    private float init_y;
    private float last_fire;
    private float random_offset;
    Rigidbody rigid_body;
    AlienState current_state;
    // Start is called before the first frame update
    void Start()
    {
        current_state = AlienState.horizontal_flight;
        init_y = transform.position.y;
        rigid_body = GetComponent<Rigidbody>();
        last_fire = Time.time;
        random_offset = Random.Range(-fire_delay, fire_delay);
    }

    // Update is called once per frame
    void Update()
    {
        if(current_state == AlienState.horizontal_flight) {
            horizontalFlight();
        } else if (current_state == AlienState.vertical_flight) {
            verticalFlight();
        }
        
        if(Time.time - last_fire + random_offset >= fire_delay) {
            fireBullet();
        }

    }

    void horizontalFlight() {
        Vector3 movement_vector = new Vector3(horizontal_speed, 0);
        rigid_body.velocity = movement_vector;
    }

    void verticalFlight() {
        Vector3 movement_vector = new Vector3(0, vertical_speed);
        rigid_body.velocity = movement_vector;

        if(init_y - transform.position.y >= vertial_step) {
            current_state = AlienState.horizontal_flight;
            horizontal_speed *= -1;
        }
    }

    void fireBullet() {
        Instantiate(bullet, fire_point);
        last_fire = Time.time;
        random_offset = Random.Range(-fire_delay, fire_delay);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Border") {
            init_y = transform.position.y;
            current_state = AlienState.vertical_flight;
        }
    }

}
