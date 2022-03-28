using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    private Snake3DInput snake3DInput;

    [SerializeField]
    private float moveSpeed = 1;
    private Vector3 moveDirection = new Vector3(0, 0, 1);
    private Direction currentDirection = Direction.Z;
    private Direction lastDirection = Direction.Z;

    private void Awake()
    {
        snake3DInput = new Snake3DInput();
    }

    private void OnEnable()
    {
        snake3DInput.Snake.Spawn.performed += gameManager.GetComponent<FoodSpawner>().SpawnFood;
        snake3DInput.Snake.XMovement.performed += ctx =>
        {
            Slither(Direction.X, ctx.ReadValue<float>());
        };
        snake3DInput.Snake.YMovement.performed += ctx =>
        {
            Slither(Direction.Y, ctx.ReadValue<float>());
        };
        snake3DInput.Snake.ZMovement.performed += ctx =>
        {
            Slither(Direction.Z, ctx.ReadValue<float>());
        };
        snake3DInput.Snake.Enable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void Slither(Direction currentDirection, float value)
    {
        if (currentDirection != lastDirection)
        {
            moveDirection.Set(0, 0, 0);
            switch (currentDirection)
            {
                case Direction.X:
                    moveDirection.x = value;
                    break;
                case Direction.Y:
                    moveDirection.y = value;
                    break;
                case Direction.Z:
                    moveDirection.z = value;
                    break;
            }
        }
        lastDirection = currentDirection;
        Debug.Log(moveDirection);
    }

    private enum Direction {X = 0, Y = 1, Z = 2}
}
