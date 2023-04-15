




-------------!!!!! For Creating Custom Room  Steps !!!!!--------------------


!!!!RULES ----> Room shapes should be same for best performance but If room shapes does not same empty blocks can spawn between the rooms but A and B values MUST be same(A and B referance to 29:41 of  second video)!!!!!

-------------------Tutorial videos--------------
First video ---> https://youtu.be/fK4MzG7w9B4

Second video ---> https://youtu.be/-jS6aJ57qU0
-------------------For Help--------------------
Discord ----> https://discord.gg/bHWssnJcfE

Instagram ----> https://www.instagram.com/alperozyurt245/?hl=tr

Gmail ----> 123alperozyurt@gmail.com

------------------------------------------------
Step 0 ----> Apply "TagManager"

Step 1 ----> Create your tiles you will use ----> Example----> Assets/Generator-Spawner/MapTiles----->DO NOT forget assign tag and layer of the parent prefab object and DO NOT forget put collider2D  (at least trigger collider) for detecting from code

Step 2 ----> Create your room shape in your mind or draw to paper or draw painting apps beacuse you will apply to RoomBuilder

Step 3 ----> Detect your main global tiles (ground tiles,  right wall tiles,  left wall tiles,  empty tiles,  ceiling tiles etc.)and make your "RoomBuilderPalette" with using objects which you detected ----> Example ----> Assets/Generator-Spawner/RoomBuilderPalette ---->

 and make all settings same as  example objects  !!(BoxCollider2D Size=0.5 0.5 and Trigger = true) just change list members of "SpawnObject" component 

Step 4 ----> Create your LR , LRB, LRBT, LRT,Start ,End rooms main tiles with using "RoomBuilder"

Step 5 ----> Paste your rooms to hierarchy and change rooms to prefab for detailed editing. Move your prefabs to Assets/Generator-Spawner/Rooms and distribute prefabs to files according to room types

Step 6 ----> Create object templates which object you want

Step 7 ----> Edit your room from prefab. Add your platfroms object spawners etc.

Step 4.1 -----> I forget to show how to create  End, Start and Empty rooms I will show this part

Step 8 ----> Add  rooms which you have created to "Room LR(Template),Room LRB(Template),Room LRBT(Template),Room LRT(Template)" templates  according to room types which you created

Step 9 ----> Calculate values which "RoomGenerator" needs. With spawning 2 room from editor