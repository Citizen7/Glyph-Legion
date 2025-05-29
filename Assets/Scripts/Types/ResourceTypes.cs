using UnityEngine;
using System;

namespace GlyphLegion {
    [Flags]
    public enum ResourceType {
        None        = 0,
        Unit        = 0x1,
        Crafting    = 0x2,
        Soldier     = 0x4,
        Archer      = 0x8,
        Cavalry     = 0x10,
        Scout       = 0x20,
        Infantry    = 0x40,
        Heavy       = 0x80,
        Scrap       = 0x100,
        Item        = 0x200,
        Bundle      = 0x400,
        Junk        = 0x800,
        Metal       = 0x1000,
        Wood        = 0x2000,
        Stone       = 0x4000,
        Elemental   = 0x8000,
        Fire        = 0x10000,
        Water       = 0x20000,
        Air         = 0x40000,
        Earth       = 0x80000,
        Void        = 0x100000
    }    
}