using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Movement player;
    public float speed;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
        gm = FindAnyObjectByType<GameManager>();
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
        if(collision.gameObject.CompareTag("Player"))
        {
            gm.health -= 1;
            gm.healthText.text = $"Health: {gm.health}";
            Destroy(gameObject);
        }
    }
}
