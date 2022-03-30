using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private Canvas gameCanvas;
    private Snake3DInput snake3DInput;

    [SerializeField]
    private float moveSpeed = 1;
    private Vector3 moveDirection = new Vector3(0, 0, 1);
    private Vector3 cameraRelativeDirection;
    private Vector3 lastDirection = new Vector3(0,0,0);

    [SerializeField]
    private Transform segmentPrefab;
    private List<Transform> segmentList;

    private void Awake()
    {
        snake3DInput = new Snake3DInput();
    }

    private void OnEnable()
    {
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
        segmentList = new List<Transform>();
        segmentList.Add(this.transform);
    }

    void Update()
    {
        transform.Translate(cameraRelativeDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void Slither(Direction directionAxis, float value)
    {
            moveDirection.Set(0, 0, 0);
            switch (directionAxis)
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
        if (moveDirection != lastDirection * -1)
        {
            cameraRelativeDirection = gameManager.transform.forward * moveDirection.z + gameManager.transform.up * moveDirection.y + gameManager.transform.right * moveDirection.x;
            lastDirection = moveDirection;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            gameCanvas.GetComponent<UIManager>().LoseScreen();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            gameCanvas.GetComponent<UIManager>().PointScored();
            gameManager.GetComponent<FoodSpawner>().SpawnFood();
        }
    }
}
