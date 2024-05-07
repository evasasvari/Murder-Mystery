using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToHandInteractor : XRBaseInteractor
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Snap the interactable's position to the interactor's position
        args.interactableObject.transform.position = transform.position;
        // match the rotation
        args.interactableObject.transform.rotation = transform.rotation;
    }
}
