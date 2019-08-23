MINA'TOA CHANGE LOG
===================

[1 April 2019]
BLM: Merging scripts from "Minitor" into "Minatoa 2019" as follows:

Setup
- Changed Project Settings/Player/Configuration/Scripting Runtime Version to ".NET 4 Equivalent"
- In Project Settings/Axes, added a new axis called "Inventory" and assigned it to key "i".

First Person Controller
- replaced standard FirstPersonController with mtFirstPersonController (and mtMouseLook).
- adjusted walk speed, footstep sound, head bob to make progress smoother.

Items on Desk
- added "Takeable" script to the crystals on the desk.
	- assigned sprites from Jayne's sprite sheet
	- some items now takeable; others not!
		- seems to require MeshFilter + MeshRenderer + MeshCollider
		- if adding these, need to assign the correct mesh to them too.
	- crystals and key now takeable.  One crystal has mis-aligned mesh.

Pools
- tried adding a waterfall to a pool (just wanted to play with particle system).

Drawers
- Cannot click on drawers.

[3 April 2019]
- got portal inside/outside colliders and logic going.
	- uses "ZoneListener" scripts on each collider.
	- the core logic is in PortalController.

- added AudioMixer to the project.
	- with two groups: sounds from the room, and sounds from within the portal.
- added AudioSource to "PortalBody" to make background portal noise.
- (main water noise comes from lower, largest pool).
- find source of gentle crystal sound in portal.
- distance to drawer is 6.4 m !? even when standing in front of it.