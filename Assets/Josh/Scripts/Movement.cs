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

    public GameObject cam;
    public Vector3 offset = new Vector3(0, 0, -10);
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
    }
}
