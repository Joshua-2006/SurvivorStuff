using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float turnspeed = 200f;
    public float thrust = 5f;
    [SerializeField] public float drag = 0.99f;
    private float horizontal;
    [SerializeField] private float vertical;
    private Rigidbody rb;

    public bool hasPowerup;
    public GameObject cam;
    public Vector3 offset = new Vector3(0, 0, -10);
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    public GameObject projectile;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float rotationAmount = horizontal * turnspeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -rotationAmount);

        rb.AddForce(transform.up * vertical * thrust);
        rb.velocity *= drag;

        cam.transform.position = transform.position + offset;

        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectile, firePoint.transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());

            IEnumerator PowerupCountdownRoutine()
            {
                yield return new WaitForSeconds(7);
                hasPowerup = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
            
    }
}
