using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform cameraPivot;
    public Transform cameraSideIndicator;
    private float cameraSpeed = 10f;
    private float marginOfError = .1f;
    private bool isRecentlyTurned = false;

    private float CalculateTanUnitCircle()
    {
        return Mathf.Abs(Mathf.Tan(Vector3.Angle(Vector3.forward, transform.position) * Mathf.Deg2Rad));
    }

    void LateUpdate()
    {
        cameraPivot.Rotate(Vector3.up, cameraSpeed * Time.deltaTime);
        if (!isRecentlyTurned)
        {
            float result = CalculateTanUnitCircle();
            if (!isRecentlyTurned && result >= 1 - marginOfError && result <= 1 + marginOfError)
            {
                cameraSideIndicator.transform.Rotate(Vector3.up, 90f);
                StartCoroutine(IndicatorTurnDelay());
            }
        }
    }

    private IEnumerator IndicatorTurnDelay()
    {
        isRecentlyTurned = true;
        yield return new WaitForSeconds(3f);
        isRecentlyTurned = false;
    }
}
