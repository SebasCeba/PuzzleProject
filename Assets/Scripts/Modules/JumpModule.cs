using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpModule : MonoBehaviour
{
    //We referencing the controller on the gameobject player 
    [SerializeField] CharacterController controller;
    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask floorLayer;

    private Vector3 velocity;
    public const float gravityAcceleration = -9.81f;
    private float earthJumpForce = 5f; 

    //Attempting to change the gravity of the player 
    public const float moonGravityAcceleration = -1.625f;
    [SerializeField] private float moonJumpForce;
    [SerializeField] private float moonGravityDuration; 
    private bool useMoonGravity = false;
    // Start is called before the first frame update
    void Start()
    {
        JumpForce = earthJumpForce; 
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        Jump();

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoonAbility(true)); 
            //MoonApplyGravity(true);
        }
        else
        {
            StopAllCoroutines(); 
            //MoonApplyGravity(false);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            velocity.y = JumpForce;
        }
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.25f, floorLayer);
    }
    private void ApplyGravity()
    {
        float gravity = useMoonGravity ? moonGravityAcceleration : gravityAcceleration;
        if (!IsGrounded())
        {
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

    private void MoonApplyGravity(bool isMoonGravity)
    {
        useMoonGravity = isMoonGravity;
        JumpForce = isMoonGravity ? moonJumpForce : earthJumpForce; 
    }

    public IEnumerator MoonAbility(bool isMoonGravity)
    {
        useMoonGravity = isMoonGravity;
        JumpForce = isMoonGravity ? moonJumpForce : earthJumpForce;
        yield return new WaitForSeconds(moonGravityDuration); 
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
}
