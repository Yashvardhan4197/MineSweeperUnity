# Minesweeper Game
A customizable Minesweeper game built using Unity with clean, scalable architecture and robust design patterns for maintainability and flexibility.
---

## Features
- Customizable Grid: Players can set the number of rows, columns, and mines to create a unique grid each time.
- Dynamic UI: The UI is divided into three components:
    - In-Game UI: For active gameplay interactions.
    - Grid Setter UI: To configure the grid dimensions and mine count.
    - Lobby UI: For starting or restarting the game.

- Mine Marking System: Allows players to flag suspected mine locations.
- Sound Integration: Includes a sound service for interactive feedback.
- Separation of Concerns:

    - Board Manager: Manages the grid and handles inputs on the board.
    - Grid Spawner: Responsible for creating the grid.
    - Bomb Spawner: Handles bomb placement and minefield generation.
    - Win Condition Manager: Checks game victory conditions.
---
## PLAY ON
  https://yashvardhan1.itch.io/minesweepery
---
## Patterns Used
1. MVC (Model-View-Controller)

- The game's core architecture is based on the MVC pattern:

    - Model: Manages the game logic and state, like grid configuration and mine placement.
    - View: Updates the UI components and reflects the game's current state.
    - Controller: Handles user inputs and connects the Model and View, ensuring clear separation of concerns.

2. Service Locator Pattern

    - Centralized access to services like grid creation, sound, and game state management without tightly coupling components.

3. Observer Pattern

    - Used for managing start, end, and pause game scenarios.
    - Ensures UI elements react dynamically to game state changes.

4. Sound Service

    - A dedicated service to manage sound effects, ensuring smooth integration across the game's components.
---