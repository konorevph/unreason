using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Note : MonoBehaviour
{
    public Material highlightMaterial;
    private Material originalMaterial;
    public MeshRenderer meshRenderer;

    private void Start()
    {
        if (meshRenderer != null)
        {
            originalMaterial = meshRenderer.material;
            meshRenderer.material = highlightMaterial;
        }

        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.onSelectEntered.AddListener(OnGrab);
        }
    }
    
    private void OnGrab(XRBaseInteractor interactor)
    {
        if (meshRenderer != null)
        {
            meshRenderer.material = originalMaterial;
        }
    }

    private void OnDestroy()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.onSelectEntered.RemoveListener(OnGrab);
        }
    }
}
