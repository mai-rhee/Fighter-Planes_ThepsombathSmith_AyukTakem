using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyonePrefab;
    public GameObject enemytwoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Createenemyone", 1, 2);
        InvokeRepeating("Createenemytwo", 4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Define Createenemyone() as a separate method within the class
    void Createenemyone()
    {
        Instantiate(enemyonePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
    void Createenemytwo()
    {
        Instantiate(enemytwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

}
