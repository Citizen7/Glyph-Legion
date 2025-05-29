using UnityEngine;

public class GlyphInactiveState : GlyphBaseState
{
    public override void EnterState(GlyphStateManager glyph)
    {
        Debug.Log($"Glyph {glyph.name} entered inactive state.");
        glyph.CancelInvoke(nameof(glyph.TriggerGeneration));
        glyph.glyphAnimator.SetBool("isActive", false);
    }

    public override void UpdateState(GlyphStateManager glyph)
    {
        
    }
}
