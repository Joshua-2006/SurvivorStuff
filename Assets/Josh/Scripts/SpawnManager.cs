using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int enemies;
    [SerializeField] private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Spawn", 1, 5);
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
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Spawn();
    }
}
