using System;
using UnityEngine;
using Zenject;

public class SystemUtils : IInitializable
{
    private Camera _camera;

    public void Initialize()
    {
        _camera = Camera.main;
    }

    public Vector3 GetLookPosition(Vector2 lineOfSight)
    {
        var mouseViewportPosition = _camera.ViewportToWorldPoint(new Vector3(lineOfSight.x, lineOfSight.y, _camera.transform.position.z));
        
        var positionToLookAt = new Vector3(mouseViewportPosition.x, 0, mouseViewportPosition.z);

        return positionToLookAt;
    }
}