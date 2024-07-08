using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PortalInputController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float mouseSensitivity;

    [Header("Modules")]
    [SerializeField] private PortalShootingModule shootingModule;
    [SerializeField] private PortalMovementModule movementModule;
    [SerializeField] private PortalJumpModule jumpModule;
    [SerializeField] private PortalInteractModule interactModule;
    [SerializeField] private PortalRestartModule restartModule;
    [SerializeField] private bool _cutsceneIsPlaying;

    private bool jumping;
    private bool canLookAround = true;
    private Vector3 moveDirection;
    private Vector2 aimDirection;

    [Header("InputSystem")]
    [SerializeField] private InputActionAsset InputSystemActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction rotateAction;
    private InputAction portalGunBlue;
    private InputAction portalGunPink;
    private InputAction laserPointerAction;
    private InputAction interactAction;
    private InputAction restartLevelAction;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //Assign Input Action values to the variables
        moveAction = InputSystemActions.FindActionMap("Player").FindAction("Move");
        jumpAction = InputSystemActions.FindActionMap("Player").FindAction("Jump");
        rotateAction = InputSystemActions.FindActionMap("Player").FindAction("Rotate");
        portalGunBlue = InputSystemActions.FindActionMap("Player").FindAction("PortalGunBlue");
        laserPointerAction = InputSystemActions.FindActionMap("Player").FindAction("LaserPointer");
        portalGunPink = InputSystemActions.FindActionMap("Player").FindAction("PortalGunPink");
        interactAction = InputSystemActions.FindActionMap("Player").FindAction("Interact");
        restartLevelAction = InputSystemActions.FindActionMap("Player").FindAction("RestartPuzzle");

        //subscribe to the necessary actions
        jumpAction.performed += OnJump;
        portalGunBlue.performed += OnPortalBlue;
        laserPointerAction.performed += OnLaser;
        portalGunPink.performed += OnPortalOrange;
        laserPointerAction.canceled += OffLaser;
        interactAction.performed += OnInteract;
        restartLevelAction.performed += OnRestart;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(restartModule != null && collision.gameObject.layer == 12)
        {
            restartModule.RestartLevel();
        }
    }
    private void OnRestart(InputAction.CallbackContext context)
    {
        if(restartModule != null && !_cutsceneIsPlaying)
        {
            restartModule.RestartLevel();
        }
        
    }

    private void OnPortalOrange(InputAction.CallbackContext context)
    {
        if (shootingModule != null && !_cutsceneIsPlaying)
        {
            shootingModule.PortalGunPink();
        }
         
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        interactModule.InteractWithObject();
    }

    private void OffLaser(InputAction.CallbackContext context)
    {
        shootingModule.LaserOff();
    }

    private void OnPortalBlue(InputAction.CallbackContext context)
    {
        if (shootingModule != null && !_cutsceneIsPlaying)
        {
            shootingModule.PortalGunBlue();
        }
            
    }

    private void OnLaser(InputAction.CallbackContext context)
    {
        if(shootingModule != null && !_cutsceneIsPlaying)
        {
            shootingModule.LaserPointer();
        }
        
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (jumpModule != null && !_cutsceneIsPlaying)
        {
            jumpModule.Jump();
        }
    }

    private void OnEnable()
    {
        InputSystemActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputSystemActions.FindActionMap("Player").Disable();
        //unsubscribe to prevent memory leaks
        jumpAction.performed -= OnJump;
        portalGunBlue.performed -= OnPortalBlue;
        laserPointerAction.performed -= OnLaser;
        portalGunPink.performed -= OnPortalOrange;
        laserPointerAction.canceled -= OffLaser;
        interactAction.performed -= OnInteract;
        restartLevelAction.performed -= OnRestart;
    }

    private void Update()
    {
        Vector2 inputDirection = moveAction.ReadValue<Vector2>();
        moveDirection = Vector2.zero;
        moveDirection.x = inputDirection.x;
        moveDirection.z = inputDirection.y;

        Vector2 inputAim = rotateAction.ReadValue<Vector2>();
        aimDirection = Vector2.zero;

        if (canLookAround)
        {
            aimDirection.x = inputAim.x * mouseSensitivity;
            aimDirection.y = -inputAim.y * mouseSensitivity;
        }

        if (movementModule != null && !_cutsceneIsPlaying)
        {
            movementModule.MoveCharacter(moveDirection);
            movementModule.RotateCharacter(aimDirection);
        }
    }

    public void LockThePlayer()
    {
        _cutsceneIsPlaying = true;
    }

    public void UnlockThePlayer()
    {
        _cutsceneIsPlaying=false;
    }

}
