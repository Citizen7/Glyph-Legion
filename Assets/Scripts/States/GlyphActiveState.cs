using System;
using UnityEngine;

public class GlyphActiveState : GlyphBaseState
{
    
    public override void EnterState(GlyphStateManager glyph) {
        Debug.Log($"Glyph {glyph.name} entered active state.");
        glyph.InvokeRepeating(nameof(glyph.TriggerGeneration), 0.5f, 0.5f);
        glyph.glyphAnimator.SetBool("isActive", true);
    }

    public override void UpdateState(GlyphStateManager glyph) {
        
    }
}
