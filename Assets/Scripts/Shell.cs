using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float speed = 0f;
    float force = 2;
    float ySpeed = 0f;
    float mass = 10;
    float drag = 2f;
    float gravity = -9.8f;
    float gAccel;
    float acceleration;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1;
        gAccel = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1 - drag * Time.deltaTime);
        ySpeed += gAccel * Time.deltaTime;
        this.transform.Translate(0, ySpeed, speed);
    }
}
