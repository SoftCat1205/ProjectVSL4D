using Fusion;
using UnityEngine;

public class MPlayerCamera : NetworkBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float aimOffsetDistance = 3f;

    private Camera _mainCamera;
    private Vector2 _latestAimDirection;


    public void UpdateAim(Vector2 direction)
    {
        _latestAimDirection = direction;
    }

    public override void Spawned()
    {
        if (!Object.HasInputAuthority)
        {
            enabled = false;
            return;
        }

        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (_mainCamera == null)
            return;

        Vector3 targetPosition = transform.position;

        targetPosition += (Vector3)(_latestAimDirection.normalized * aimOffsetDistance);

        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, targetPosition + Vector3.forward * -10f, followSpeed * Time.deltaTime);
    }
}