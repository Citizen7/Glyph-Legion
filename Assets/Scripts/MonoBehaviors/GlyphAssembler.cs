using GlyphLegion;
using UnityEngine;

public class GlyphAssembler : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public ResourceController resourceController;
    public GlyphStateManager glyphStateManager;
    public ResourceCreationGlyph glyphButton;
    public ResourceDisplay resourceDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Wire button to state manager
        glyphButton.OnGlyphActivate += glyphStateManager.HandleActivate;
        glyphButton.OnGlyphDeactivate += glyphStateManager.HandleDeactivate;
        glyphStateManager.glyphAnimator = glyphButton.GetComponent<Animator>();

        // Wire state manager to controller
        glyphStateManager.OnGenerateResource += resourceController.GenerateResource;

        // Wire controller to display
        resourceController.OnResourceChanged += resourceDisplay.UpdateDisplay;
    }

}
