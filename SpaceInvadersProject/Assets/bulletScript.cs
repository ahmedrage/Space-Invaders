using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed;
    public string target_tag;
    private Rigidbody rigid_body;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    void moveBullet() {
        Vector3 movement_vector = new Vector3(0, speed);
        rigid_body.velocity = movement_vector;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == target_tag) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
