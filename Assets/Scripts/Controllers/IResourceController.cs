
using System;

namespace GlyphLegion {
    public interface IResourceController {
        event Action ResourceIncreased;
        event Action ResourceDescreased;
        event Action<int> OnResourceChanged;
    }
}