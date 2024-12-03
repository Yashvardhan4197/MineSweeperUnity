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
## SCREENSHOTS
<img src="https://github.com/user-attachments/assets/3ee079e2-1514-491b-baaf-0df1dee27af8" alt="Screenshot 1" width="400" height="600" style="margin: 20px;">
&nbsp;&nbsp;&nbsp;&nbsp;
<img src="https://github.com/user-attachments/assets/2b7f1579-081e-41e7-9d8b-4ef5259bd221" alt="Screenshot 2" width="400" height="600">
<br><br>
<img src="https://github.com/user-attachments/assets/c6bb5479-ddb9-4a4c-a18b-3bd119e56d81" alt="Screenshot 3" width="400" height="600" style="margin: 20px;">
&nbsp;&nbsp;&nbsp;&nbsp;
<img src="https://github.com/user-attachments/assets/3c8615d6-ef6d-4a27-8c78-e89ef81d82e8" alt="Screenshot 4" width="400" height="600">
