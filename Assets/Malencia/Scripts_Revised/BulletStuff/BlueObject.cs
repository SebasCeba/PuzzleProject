using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.SceneView;

public class BlueObject : WarpObjects
{
    [SerializeField] private float bulletResetTime;
    public Rigidbody rb;
    private BluePortalBulletPool poolOwner;
    private float timerToReset;
    private bool reseting;
    private const int blueID = 1;
    [SerializeField] private int portalSetLayer;
    [SerializeField] private int portalLayer;
    [SerializeField] private PortalGameManager _portalManager;
    [SerializeField] private PortalMovementModule _portalMovementModule;
    [SerializeField] private PortalPool bluePool;


    [SerializeField] private PortalGameManager PortalGameManager;

    public void LinkToPortalGameManager(PortalGameManager portalManager)
    {
        PortalGameManager = portalManager;
    }


    public void LinkToPool(BluePortalBulletPool owner)
    {
        poolOwner = owner;
    }

    public void LinkToPortalPool(PortalPool owner)
    {
        bluePool = owner;
    }

    public void GetRotation(PortalMovementModule module)
    {
        _portalMovementModule = module;
    }

    private void Start()
    {
        int portalSetLayer = LayerMask.NameToLayer("SetPortalLayer");
        int portalLayer = LayerMask.NameToLayer("Portal");
    }



    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.layer == 11)
        //{
        //    Portal thisPortal = collision.gameObject.GetComponent<Portal>();

        //    if(thisPortal == null)
        //    {
        //        return;
        //    }

        //    Teleport();
        //}
        if(collision.gameObject.layer == 10)
        {
            //Vector3 location = collision.GetContact(0).point;
            //Vector3 normal = collision.GetContact(0).normal;
            //bluePool.PortalLocation(location, normal);

            //bool PlacementSuccessful = _portalManager.GetPortal(blueID).IsPlaced;

            //if(PlacementSuccessful)
            //{

            //}


            // Orient the portal according to camera look direction and surface direction.
            var cameraRotation = _portalMovementModule.transform.rotation;
            var portalRight = cameraRotation * Vector3.right;

            if (Mathf.Abs(portalRight.x) >= Mathf.Abs(portalRight.z))
            {
                portalRight = (portalRight.x >= 0) ? Vector3.right : -Vector3.right;
            }
            else
            {
                portalRight = (portalRight.z >= 0) ? Vector3.forward : -Vector3.forward;
            }

            var portalForward = -collision.GetContact(0).normal;
            var portalUp = -Vector3.Cross(portalRight, portalForward);

            var portalRotation = Quaternion.LookRotation(portalForward, portalUp);

            Vector3 normposition = collision.GetContact(0).normal;
            Vector3 position = collision.GetContact(0).point;

            // Attempt to place the portal.
            bool wasPlaced = PortalGameManager.GetPortal(blueID).PlacePortal(collision.collider, position, portalRotation);
                
            if(wasPlaced)
            {
                Debug.Log("Blue was placed");
            }

            gameObject.SetActive(false);
        }
    }

    public void ResetBackToPool()
    {
        rb.velocity = Vector3.zero;
        reseting = false;
        poolOwner.ResetBullet(this);
    }

    public void ResetBackToPool(float time)
    {
        timerToReset = bulletResetTime;
        reseting = true;
    }

    private void Update()
    {
        if (reseting)
        {
            timerToReset -= Time.deltaTime;
            if (timerToReset <= 0)
            {
                ResetBackToPool();
            }
        }
    }
}
