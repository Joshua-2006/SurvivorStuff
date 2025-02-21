using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int enemies;
    [SerializeField] private Enemy enemy;
    public float spawnInterval = 5;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("Spawn", 1, spawnSpeed);
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Spawn();
            spawnInterval *= 0.5f;
            timer = spawnInterval;
        }
        if(spawnInterval == 0)
        {
            spawnInterval = 5;
        }
        
    }
    public Vector3 SpawnPos()
    {
        float xRange = Random.Range(-10, 10);
        float yRange = Random.Range(-10, 10);
        Vector3 randomPos = new Vector3(xRange, yRange, 0);
        return randomPos;
    }
    public void Spawn()
    {
        Instantiate(enemy, SpawnPos(), enemy.transform.rotation);
    }
    public void Spawn2()
    {
        Instantiate(this, SpawnPos(), transform.rotation);
    }
    /* IEnumerator Wait()
     {
         yield return new WaitForSeconds(5);
         spawn = true;
         if(spawn)
         {
             spawn = false;
             Instantiate(this, transform.position, transform.rotation);
         }
        
      }*/
}
