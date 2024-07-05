using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementModule : MovementModule
{
    [SerializeField] private float maxUp;
    [SerializeField] private float maxDown;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;

    public override void MovePlayer(Vector3 direction)
    {
        return;
    }
    public override void RotatePlayer(Vector3 direction)
    {
        aimDirection.x = direction.x;
        aimDirection.y += direction.y * Time.deltaTime;

        aimDirection.x = Mathf.Clamp(aimDirection.y, -maxLeft, maxRight);
        aimDirection.y = Mathf.Clamp(aimDirection.y, -maxDown, maxUp);

        if (headUpDown) headUpDown.localEulerAngles = new Vector3(aimDirection.y, 0, 0);

        //To move the camera on it's left or right (y axis)  
        transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime);
    }
}
