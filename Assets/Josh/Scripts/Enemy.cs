using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Movement player;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
