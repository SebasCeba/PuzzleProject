using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpModule : MonoBehaviour
{
    //We referencing the controller on the gameobject player 
    [SerializeField] CharacterController controller;
    [SerializeField] private LayerMask floorLayer;
    [SerializeField] private float moonJumpForce;
    [SerializeField] private float earthJumpForce = 5f;
    [SerializeField] private float moonGravityDuration;

    private float JumpForce;
    private Vector3 velocity;
    private const float gravityAcceleration = -9.81f;
    private const float moonGravityAcceleration = -1.625f;
    private bool useMoonGravity = false;

    void Start()
    {
        JumpForce = earthJumpForce; 
    }
    void Update()
    {
        ApplyGravity();
        Jump();

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoonAbility(true)); 
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            velocity.y = JumpForce;
        }
    }
    private void ApplyGravity()
    {
        if (!IsGrounded())
        {
            float gravity = useMoonGravity ? moonGravityAcceleration : gravityAcceleration;
            //gravity use to be gravityAcceleration 
            velocity.y += gravity * Time.deltaTime;
            if (velocity.y < -9f)
            {
                velocity.y = -9f;
            }
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0;
        }
        controller.Move(velocity * Time.deltaTime);
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.25f, floorLayer);
    }
    public IEnumerator MoonAbility(bool isMoonGravity)
    {
        useMoonGravity = isMoonGravity;
        JumpForce = isMoonGravity ? moonJumpForce : earthJumpForce;
        yield return new WaitForSecondsRealtime(moonGravityDuration);
        useMoonGravity = false;
        JumpForce = earthJumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MoonRoom"))
        {
            MoonApplyGravity(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MoonRoom"))
        {
            MoonApplyGravity(false);
        }
    }
    private void MoonApplyGravity(bool isMoonGravity)
    {
        useMoonGravity = isMoonGravity;
        JumpForce = isMoonGravity ? moonJumpForce : earthJumpForce;
    }
}
