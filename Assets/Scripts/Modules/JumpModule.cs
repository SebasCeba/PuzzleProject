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

    private Coroutine moonGravityCoroutine; 
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
            //This should check if the coroutine is on or not
            if(moonGravityCoroutine != null)
            {
                StopCoroutine(moonGravityCoroutine);
            }
            moonGravityCoroutine = StartCoroutine(MoonAbility()); 
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
    //The gravity ability is here so if you need to change anything it would be here. So when making modules, cut everything here and below. 
    private void MoonApplyGravity(bool isMoonGravity)
    {
        useMoonGravity = isMoonGravity;
        JumpForce = isMoonGravity ? moonJumpForce : earthJumpForce;
    }
    //This boolen was ruining the code and now the code is feeling a lot better 
    public IEnumerator MoonAbility()
    {
        //This will change the gravity of earth to the moon's gravitational pull 
        MoonApplyGravity(true); 
        yield return new WaitForSeconds(moonGravityDuration);
        //Returns the gracitational pull of the moon to the earth's pull.
        MoonApplyGravity(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Use tags whenever you want to shift the gravity of the player
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
