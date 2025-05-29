using System;
using GlyphLegion;
using UnityEngine;

public class GlyphStateManager : MonoBehaviour
{
    public GlyphBaseState currentState;
    public GlyphActiveState ActiveState = new GlyphActiveState();
    public GlyphInactiveState InactiveState = new GlyphInactiveState();
    public Animator glyphAnimator;

    public event Action OnGenerateResource;

    void Awake() {
        Debug.Log($"Awake called on {this.name}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        currentState = InactiveState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update() {
        currentState.UpdateState(this);
    }

    public void SwitchState(GlyphBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }    

    public void TriggerGeneration() {
        OnGenerateResource?.Invoke();
    }
    
    public void HandleActivate() {
        SwitchState(ActiveState);
    }

    public void HandleDeactivate() {
        SwitchState(InactiveState);
    }
}
