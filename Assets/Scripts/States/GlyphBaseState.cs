using UnityEngine;

public abstract class GlyphBaseState
{
    public abstract void EnterState(GlyphStateManager glyph);
    public abstract void UpdateState(GlyphStateManager glyph);
}
