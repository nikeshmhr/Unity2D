## 9-Dec, 018
#### TASKS TO DOs:
* Change Player Sprite DONE
* Add Animation for Player (DONE)

#### PROBLEMS:
* AIR CONTROL NOT WORKING (WAS WORKING BEFORE) => Jump Animation removed

#### TEMP
##### PLAYER ANIMATION
    Idel -> Walk (Speed > 0.01)
    Walk -> Idel (Speed < 0.01)
    Any -> Jumping (Ground false)
    Jumping -> Idel (Ground true)


## 10 Dec, 018
#### TASKS TO DOs:
* Player landing particle system (DONE => Might need polishing)
* Player scale (DONE => Scaled to 80 pixels per unit from 50)
* Add plank spawn points (DONE)
  * spawn 2 planks per row (_ = blank, - = plank)
  * -_-_-   (Here randomly remove either right or left plank)
  * _-_-_   (This will not change)

## 11 Dec, 018
#### TASKS TO DOs:
* Camera shake (Done)
* Add more Look & Feel to the Environment (PARTIALLY DONE), Player
* Environment update:
  * Black & White look and feel (DONE)

## 14 Dec, 018
#### TASKS TO DOs:
* Add loose planks (every X seconds)
  * We don't need to check every frame if its time to spawn broken plank, FIX THIS.. (N/A)
* Add sound clips for:
  * death (DONE)
  * jump
  * walk
  * land (DONE)
* Spawn Simple Head (Changing color)

## 26 Dec, 018
#### TASKS TO DOs:
* Work on broken plank mechanics (DONE)
* Design UI (HUD) (DONE)
  * Add play/pause functionality (DONE)
  * Play/Pause sound effects (DONE)
* Design Start Screen (WIP/DONE)
* Add Scoring system / Save HighScore (DONE)
* HIGHSCORE SET:
  * Slow down timescale for few milliseconds
  * Particle System (DONE)
  * Add sound effect that goes with particle system