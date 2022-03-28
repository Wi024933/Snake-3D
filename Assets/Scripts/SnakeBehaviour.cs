using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    private Snake3DInput snake3DInput;

    private void Awake()
    {
        snake3DInput = new Snake3DInput();
    }

    private void OnEnable()
    {
        snake3DInput.Snake.Spawn.performed += gameManager.GetComponent<FoodSpawner>().SpawnFood;
        snake3DInput.Snake.Spawn.Enable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
