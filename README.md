# Elevens Project — Final Submission (C#)

By **Bilal Burton**

## Overview

This project demonstrates full class design, abstraction, and gameplay logic for a console-based implementation of the **Elevens** card game.  
It uses OOP concepts such as inheritance, encapsulation, and polymorphism through the `Card`, `Deck`, `Board`, and `ElevensBoard` classes.

---

## Implemented Classes

| Class          | Status   | Description                                                                                               |
| -------------- | -------- | --------------------------------------------------------------------------------------------------------- |
| `Card`         | Complete | Represents a single playing card with rank, suit, and value.                                              |
| `Deck`         | Complete | Builds, shuffles, and deals cards.                                                                        |
| `Board`        | Complete | Abstract base class with methods for dealing, displaying, and managing cards.                             |
| `ElevensBoard` | Complete | Contains full game logic for legal moves (11-pairs, JQK triples), win/loss detection, and deck refilling. |
| `Program`      | Complete | Main driver that runs the full playable game loop with user input.                                        |

---

## Features Added Over Time

### First Submission (10-24-2025)

- Object-oriented design using abstraction and inheritance
- Deck creation, shuffling, and card dealing
- Legal move logic for **pairs summing to 11**
- **Face-card triple handling** (Jack, Queen, King)
- Console-based feedback for **valid/invalid moves**

### Second Submission (11-9-2025)

- Handling of face card triples (Jack, Queen, King)
- Win/Loss condition detection

### Final Submission (11-9-2025)

- Full playable game loop with user input and validation
- Board and deck fixes preventing resets during refills
- Added `RefillBoard()` for dynamic replacements
- Implemented `AnotherPlayIsPossible()` for JQK and 11-pair logic
- Console messages for move feedback and end-game conditions
- **Quit option (`q` / `quit`)** for graceful exit
- **Dynamic board refilling** without resetting after valid moves

---

## How to Compile and Run

### 🧠 Requirements

- [.NET 6.0 or higher](https://dotnet.microsoft.com/en-us/download)
- Visual Studio Code or any C# IDE

### 🛠️ Compile

- Open a terminal in your project folder and run:

```bash
- dotnet build
- dotnet run

---

## Gameplay Instructions
1. The game automatically deals **9 cards** from the shuffled deck.
2. Type **two positions** (e.g. `0,1`) to select a pair summing to **11**.
3. Type **three positions** (e.g. `0,1,2`) if they form a **Jack, Queen, and King** combo.
4. Type **`q`** or **`quit`** at any time to exit the game.
5. The game ends when **no more moves are possible (loss)** or when the **deck runs out (win)**.

---

## Summary and my struggles with the project

- One of my main challenges was ensuring the board refilled correctly without clearing the entire set of cards each move. To fix it, I had to seperate dealboard into two different methods. One refills the board when cards are removed and the other resets the deck at the start of the game, making sure the existing cards stay consistent without resetting every time.

- Another challenge I had was implementing abstract methods for the base board class to make sure JQK combo detection worked.

- With those challenges in mind I can honestly say that I was able to create a solid elevens game thats fully functional and structured. Demonstrating a solid understanding of object oriented principles in action.
```
