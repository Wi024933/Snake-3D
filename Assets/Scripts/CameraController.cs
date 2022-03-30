using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform cameraPivot;
    private Snake3DInput snake3DInput;

    float mouseX;

    private void Awake()
    {
        snake3DInput = new Snake3DInput();
    }

    private void OnEnable()
    {
        snake3DInput.Snake.MouseX.performed += ctx => mouseX = ctx.ReadValue<float>();
        snake3DInput.Snake.MouseX.Enable();
    }

    private void Mouse(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    void Update()
    {
        cameraPivot.Rotate(Vector3.up, mouseX * 0.5f);
    }
}
