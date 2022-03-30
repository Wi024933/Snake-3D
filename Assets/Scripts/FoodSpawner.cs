using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject foodGameObject;
    
    private int snakePitRadius = 10;

    void Start()
    {
        //Vector3 lowerSnakePitCorner = new Vector3(-snakePitRadius, -snakePitRadius, -snakePitRadius);
        //Vector3 upperSnakePitCorner = new Vector3(snakePitRadius, snakePitRadius, snakePitRadius);

        Instantiate(foodGameObject, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        
    }
    
    public void SpawnFood()
    {
        Instantiate(foodGameObject, new Vector3(RandomSnakePitPoint(), RandomSnakePitPoint(), RandomSnakePitPoint()), Quaternion.identity);
    }

    private int RandomSnakePitPoint()
    {
        return Random.Range(-snakePitRadius + 1, snakePitRadius - 1);
    }
}
