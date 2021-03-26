# GroupProject_CAP4720

![Image](https://github.com/maslychm/GroupProject_CAP4720/blob/master/Assets/Resources/Scene.PNG)

### Project Goal:
The goal of our project is to learn how to use shaders effectively, and how to dynamically apply them to objects in a Unity scene, based only on user input. We want to learn HLSL and be able to compute shades of objects based on the following data: player position and speed relative to the objects in scene, game "score", time passed in the game and speed of each object separately. We want to make use of Unity's built-in Physics to get the above listed.

#### What we will demonstrate:
We want to demonstrate the effective use of shaders and provide visual feedback based on user input. The only form of information given back to the player will be through visual cues (no text-prompts outside of informing players what the controls are)

#### Running the project for class presentation:
  1)	Extract the FIXME.zip
  2)	In folder GP run GroupProject_CAP4720.exe
  3)	To exit, press `[Alt + F4]`
  4)	In folder GP2 Run the run GroupProject_CAP4720.exe
  5)	To exit, press `[Alt + F4]`

#### Link to GitHub Repository of the project:
  [GroupProject_CAP4720](https://github.com/LynchJ13/GroupProject_CAP4720)

#### Contribution:
  1)	Shaders that use object’s position to compute vertices and their colors.
  2)	Interaction technique for picking up objects for testing positional shaders

#### Shaders Developed:
  1)	BarySphere – Calculate displacement using displacement map, interpolate between colors of Green and Red multiplied by a dynamic color noise map based on distance from another object in the scene.
  2)	SpikeSphere – Calculate displacement using displacement map based on distance from another object in the scene. Calculate color of the spike based on amount of displacement of each vertex from the original surface of the sphere.
  3)	HoloShader – Apply color from noise along only one axis and set transparency by turning down the alpha channel.
  4)	SpinningSphere – Apply texture based on time passed since the start of the scene. Multiply interpolation between two colors and sin(time) since the start of scene.
  5)	TranspatentMaterial – simple color with alpha channel tuned down.

### Interactions Developed:
#### Picking up Objects:
We used a ready FPS Camera Control from Unity Standard assets and added ability to pick up objects using the following:
   1. Child an empty object [Guide] to the FirstPersonCharacter object 
   2.	Add a MoveObject script to the objects to objects we want to make interactable
   3.	MoveObject script does the following:
        1. On Mouse1 down press, check if a ray from center of the camera intersects with a “PickupAble” object
        2. If yes, child that object to the [Guide] listed above
        3. Upon release of Mouse1 press, remove the parenting and place original object into original category
 
 
#### Button Press: 
When user gets close enough to an object that has a DoorButton script attached to it, on a press of ‘e’ key, set a Door object in the scene to inactive.
Object attachment to point in space: When an object gets close enough to a certain position in space (in our scene, it’s a certain offset in Y direction from an object), parent it to that object, until a Picking Up Objects script takes over.

### Resources used:
  - Unity Standard Assets
    - FPS Controller
  - Unity Documentation 
    - [Unity3D Documentation](https://docs.unity3d.com/ScriptReference/)
  - Reference to HLSL Shader Language that ran with Shade Lab (Unity’s Shading language)
    - [Microsoft HLSL Documentation](https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-reference)
    - [Unity Shader Tutorial](https://docs.unity3d.com/Manual/ShaderTut2.html)
  - Publicly available free textures 
    - [3DTextures](https://3dtextures.me/tag/spaceship/)
      
### Project outline:
  - Week 1: Implementing basic physics and user input
  - Week 2: Applying Textures, HLSL Shaders to the scene
  - Week 3: Varying shades of objects based on user input
  - Week 4: Bug-Fixing and Fine-tuning

#### Project Members:
   [John Lynch](https://github.com/maslychm)   
   [Mykola Maslych](https://github.com/Fribrios)
