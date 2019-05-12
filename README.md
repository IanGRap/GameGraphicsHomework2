# GameGraphicsHomework2

Instructions:
  Press the space bar to change scenes while playing.
  On the terrain scene, use up and down on the arrow keys to change the water level. Use left and right on the arrow keys to change 
  the terrain's height.
  
Scene A:
  I used the bloom shader we made in lab here (Assets/Bloom.shader).
  For the outline shader I adapted the code from this video: https://www.youtube.com/watch?v=OJkGGuudm38.
    My main difference is that the fragment shaders final color is lerped from blue to pink. The more pink it is, the closer the normal
    is to being perpendicular to the camera (Assets/Rim1.shader).
  I downloaded the car model from a free asset website.
  Screenshot: (Assets/AScreenshot.png)
    
Scene B:
  I adapted Angus's code throughout here.
  The shader was made by combining his Reflection.shader and his HillFromTexture.shader. My terrain shader (Assets/terrain.shader) 
  generates the terrain like HillFromTexture, but if the fragment is below the water level, it lerps the reflection from the skybox with
  the terrain texture. 
  The mesh is generated from the MeshController script (Assets/MeshController.cs). It is the same as Angus's CreateMeshSimple script
  except I added controls for changing the height of the terrain and the water level in the shader.
  I downloaded the skybox from the asset store. I got the water texture from google images.
  Screenshot: (Assets/BScreenshot.png)

Download: IanRapoport.com/IanRapoportHomework2.zip
