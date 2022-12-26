## Used Technologies:
- **Zenject** for DI
- **Unity Remote Config** for keeping data

The project consists of 2 scenes: loading screen scene that responsible for fetching data from the remote config and the main scene where the main gameplay happens.

![image](https://user-images.githubusercontent.com/82056646/209551157-d8ffe485-f016-4867-9ed2-e5704879fb03.png)

Every scene is started from the **Bootstrap** object which is the start point of the scene.

## Parts

- Zenject Installers
  - Responsible for injecting objects into classes using them
- Bootstraps
  - Entry Point of the every scene
- Views
  - Plain MonoBehaviours on prefabs controlling instances of the game
- Models
  - Data of the instance 
- UI
  - Classes responsible for updating the user interface
- Serialization
  - The project uses simple BinaryFormatter to provide the saving system
- Utils
  - Help classes like ObjectPool that can be used in the different part of the program  
