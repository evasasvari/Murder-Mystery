using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeRayColor : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color hoverColor = Color.green;
    [SerializeField] private Color selectColor = Color.blue;

    private XRRayInteractor rayInteractor;
    private Material myMaterial;

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            myMaterial = renderer.material;
        }
        else
        {
            Debug.LogWarning("Renderer component missing, cannot set colors on material.");
        }

        if (myMaterial != null)
        {
            myMaterial.color = defaultColor;
        }

        if (rayInteractor != null)
        {
            rayInteractor.hoverEntered.AddListener(OnHoverEntered);
            rayInteractor.hoverExited.AddListener(OnHoverExited);
            rayInteractor.selectEntered.AddListener(OnSelectEntered);
            rayInteractor.selectExited.AddListener(OnSelectExited);
        }
        else
        {
            Debug.LogError("XRRayInteractor component is not attached to this GameObject.");
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (myMaterial != null)
        {
            myMaterial.color = hoverColor;
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        if (myMaterial != null)
        {
            myMaterial.color = defaultColor;
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (myMaterial != null)
        {
            myMaterial.color = selectColor;
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (myMaterial != null)
        {
            myMaterial.color = defaultColor;
        }
    }

    void OnDestroy()
    {
        if (rayInteractor != null)
        {
            rayInteractor.hoverEntered.RemoveListener(OnHoverEntered);
            rayInteractor.hoverExited.RemoveListener(OnHoverExited);
            rayInteractor.selectEntered.RemoveListener(OnSelectEntered);
            rayInteractor.selectExited.RemoveListener(OnSelectExited);
        }
    }
}
