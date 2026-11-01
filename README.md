# Space Observatory – 3D UI in VR

Exercise #2 for Interactive Virtual Environments 2026-27

The user stands in an open-air space observatory under a starry sky. On a console in front of them sit three small planets: **Earth**, **Moon** and **Mars**. Choosing a planet plays a short NASA video about it on a large screen, with sound coming from the screen.

## Requirements

- **Unity 6000.6.3f1** (Unity 6)
- Universal Render Pipeline (URP)
- XR Interaction Toolkit 3.6.1 (with *Starter Assets* and *XR Interaction Simulator* samples)
- XR Plug-in Management / OpenXR

## How to run

1. Open the project folder in Unity Hub (**Add → Add project from disk**) using Unity 6000.6.3f1.
2. Open the scene `Assets/Scenes/Main.unity`.
3. Press **Play**.
   - **Without a headset:** the XR Interaction Simulator is in the scene. Press **Y** in the Game view to show its controls.
   - **With a Meta Quest:** build for Android with OpenXR enabled, or install the `.apk` from the Releases page.

## Controls

| Action | VR controllers | Simulator |
|---|---|---|
| Look around | Move your head | Mouse (see **Y** panel) |
| Point at a planet | Aim the controller ray | Move the simulated controller |
| Choose a planet | Grip button | Grip key (see **Y** panel) |
| Pause / resume the video | Choose the same planet again | Same |

## Project structure

```
Assets/
├── Scenes/Main.unity        Main scene
├── Scripts/
│   ├── PlanetButton.cs      Button states and feedback for each planet
│   └── VideoScreen.cs       Plays the chosen video, keeps one selection, dims the light
├── Materials/               Room, console, screen and planet materials
├── Textures/
│   ├── Planetas/            Earth, Moon and Mars textures
│   ├── Estrelas.png         Starfield sky (equirectangular)
│   └── RT_Screen            Render texture the video player draws into
└── Videos/                  NASA videos (terra.mp4, lua.mp4, marte.mp4)
```

The scene layout, materials, video assignments and event connections are all set up in the Unity editor. The Interactable events (Hover Entered/Exited, Select Entered/Exited) are connected to `PlanetButton` in the Inspector, so the wiring is visible without reading code. The scripts only handle behaviour: button feedback and video playback.

## Credits

- **Videos:** NASA, from the NASA Image and Video Library (images.nasa.gov). Public domain under the NASA Media Usage Guidelines.
  - Earth: *[nasa.gov](https://images.nasa.gov/details/Earth%20Views%20from%20the%20International%20Space%20Station)*
  - Moon – Apollo 11: *[nasa.gov](https://images.nasa.gov/details/Apollo_11_moonwalk_montage_720p)*
  - Mars: *[nasa.gov](https://images.nasa.gov/details/JPL-20231227-M2020f-0001-Perseverance%20Rover%20Zooms%20in%20on%20Ancient%20Mars%20River)*
- **Planet textures:** [Solar System Scope](https://www.solarsystemscope.com/textures/), based on NASA data, licensed under CC BY 4.0.
- **Click sound:** "Button Pop" from the XR Interaction Toolkit Starter Assets (Unity Technologies).
