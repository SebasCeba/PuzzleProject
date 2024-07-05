
using UnityEngine;


public class Microscope : MonoBehaviour , IInteracterable
{
    [SerializeField] private Camera microScopecam;
    [SerializeField] private InputController player;
    [SerializeField] private MovementModule microscope;
    public void OnHoverEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnHoverExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InteractModule interactModule)
    {
        player.cam = microScopecam;
        player.movementModule = microscope;
    }

 
}
