using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tmp
{
    public class InputController : MonoBehaviour
    {
        [Header("Camera & Sensitivity")]
        //To direct the camera with the mouse
        [SerializeField] private Camera cam;
        [SerializeField] private float mouseSense;

        [Header("Modules")]
        [SerializeField] private ShootingModule shootingModule;
        [SerializeField] private MovementModule movementModule;
        [SerializeField] private JumpModule jumpModule;
        [SerializeField] private InteractModule interactModule;
        [SerializeField] private HealthModule healthModule;

        private bool jumping;
        private bool canLookWithMouse;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        // Start is called before the first frame update
        private void Start()
        {
            cam.transform.localEulerAngles = transform.localEulerAngles;
            Invoke("EnableMouseInput", 1f);
        }
        private void EnableMouseInput()
        {
            canLookWithMouse = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!canLookWithMouse)
            {
                return;
            }

            Vector3 moveDirection = Vector2.zero;
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.z = Input.GetAxisRaw("Vertical");

            Vector2 aimDirection = Vector2.zero;
            aimDirection.x = Input.GetAxisRaw("Mouse X") * mouseSense;
            aimDirection.y = -Input.GetAxisRaw("Mouse Y") * mouseSense;

            if (shootingModule != null && Input.GetMouseButtonDown(0))
            {
                shootingModule.Shoot();
            }
            if (interactModule != null && Input.GetKeyDown(KeyCode.E))
            {
                interactModule.InteractWithObject();
            }
            if (jumpModule != null && Input.GetKeyDown(KeyCode.Space))
            {
                jumpModule.Jump();
            }
            if (movementModule != null)
            {
                movementModule.MovePlayer(moveDirection);
                movementModule.RotatePlayer(aimDirection);
            }
        }
    }
}