# Arkanoid

A brick breaker game with custom mechanics, built in Unity 2021.3 (C#).

![Gameplay](docs/gameplay.gif)

## Gameplay

- **Bombs**: blocks that destroy blocks horizontally, vertically or of the same color
- **Boosts** dropping from destroyed blocks:
  - fireball (passes through blocks)
  - extra ball
  - gun on the platform (shoots bullets)
  - platform size up / down
  - platform speed up / down
  - ball speed change
  - health up / down
- **Ball speed increases** as the level progresses
- **Level packs** (Andromeda, Orion, Nebula, Sigara, Sombrero) with an energy system to start a level
- Lives, victory / lose popups, level skip
- **Localization**: English / Russian, switchable in game

## Architecture

- **Custom DI**: project and scene contexts, installers, service container
- **Component + System architecture**: game logic is split into data components
  (`MovingComponent`, `HealthComponent`, `BoostComponent`, ...) and systems that process them
  (`HealthSystem`, `BoostSystem`, `CollisionSystem`, ...). New mechanics are added
  as a new component and system without changing existing code.
- **State machine** for game flow (setup, play, victory, lose, reload level)
- **Data-driven levels**: levels are loaded from JSON and built on a grid
- **Custom localization module**: CSV tables, language switching at runtime
- **Object pooling** for blocks, bullets, effects and popups
- **DOTween** animations, camera shake, particle effects

## Project structure

```
Assets/App/Scripts/
├── Infrastructure/   # entry point, scene loading, states, project settings
├── Libs/             # DI, components/systems, pool, localization, asset provider
└── Scenes/
    ├── StartScene/       # main menu, language selection
    ├── PackSelectScene/  # level packs, energy
    └── GameScene/        # ball, platform, blocks, boosts, bombs, HUD, popups
```

## How to run

1. Open the project in **Unity 2021.3.28f1**
2. Open `Assets/App/Scenes/Start.unity`
3. Press Play
