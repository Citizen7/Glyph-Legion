# Glyph Legion

Glyph Legion is a idle/clicker resource management game with light story elements about memory, magic, and rebuilding after collapse. Players use animated glyphs to gather resources, assign task managers, level skills, and progress the story.

## Features
- Modular save/load system using odin json serializer. Designed to handle multiple save states with persistent system config across save states. Architecture in place for adding cloud save ability at a later date.
- Basic unit classes: Scout, Infantry, Archer (for classic rock/paper/scissors strengths/weaknesses)
- Five element system: Fire, Water, Air, Earth, Void
- Click-based controls for custom animated glyphs
- Resource generation system (incremental & real-time)

## In Development
- Custom glyph drawing input system
- Combat & scouting
- Persistent world state across missions
- NPC/narrator story elements

## Tools & Tech
- Unity 6, C#, [Odin Serializer](https://github.com/TeamSirenix/odin-serializer)
- Versioned with Git, documented with in-code comments
