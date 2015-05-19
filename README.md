# CollisionFromRaycast

*CollisionFromRaycast* extension for Unity. Use it to detect collision with raycast.

Licensed under MIT license. See LICENSE file in the project root folder.   
Extensions with version below 1.0.0 are considered to be pre/alpha and may not work properly.

![CollisionFromRaycast](/Resources/cover_screenshot.png?raw=true)

## Features

* Add multiple callbacks to execute on raycast hit
* Pause game on collision
* Disable component after collison
* Set raycast length
* Draw ray gizmo

## Resources

Nothing here.

## Quick Start

1. Clone repository into the *Assets* folder.
2. Select game object in the hierarchy window and from the *Component* menu
   select *CollisionFromRaycast* to add component to the selected game object.
3. Set options and add callback action. Your callback method can take a *RaycastHit* as an argument.
   Hit play and when a collision is detected, the callback action will be executed.

## Help

Just create an issue and I'll do my best to help.

## Contributions

Pull requests, ideas, questions or any feedback at all are welcome.

## Versioning

Example: `v0.2.3f1`

- `0` Introduces breaking changes.
- `2` Major release. Adds new features.
- `3` Minor release. Bug fixes and refactoring.
- `f1` Quick fix.