using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private Canvas gameCanvas;
    [SerializeField]
    private Camera gameCamera;
    private Snake3DInput snake3DInput;

    [SerializeField]
    private float moveSpeed = 1;
    private Vector3 moveDirection = new Vector3(0, 0, 1);
    private Vector3 cameraRelativeDirection;
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
        transform.Translate(cameraRelativeDirection * moveSpeed * Time.deltaTime, Space.World);
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
        cameraRelativeDirection = gameManager.transform.forward * moveDirection.z + gameManager.transform.right * moveDirection.x;
        lastDirection = currentDirection;
    }

    private void GetSideWithCamera()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit.");
        if (other.CompareTag("Border"))
        {
            Debug.Log("Border");
            gameCanvas.GetComponent<UIManager>().LoseScreen();
        }
    }
}
