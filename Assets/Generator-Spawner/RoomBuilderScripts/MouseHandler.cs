using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseHandler : MonoBehaviour
{

    // Inspired form --------> https://www.youtube.com/watch?v=waEsGu--9P8&t=407s&ab_channel=CodeMonkey 
    Grids grid;
    private float cellSize;
    private float mouseDistance;
    [SerializeField] string RoomName;
    List<Vector3> placedTile = new List<Vector3>();
    [SerializeField] GameObject TilePrefab;
    private GameObject ParentRoom;
    [SerializeField] LayerMask TileSpawnpointLayer;
    [SerializeField] LayerMask RoomLayer;
    [SerializeField] Vector2 EraserSize;
    [SerializeField] Sprite CenterSprite;
    
    
    private void Start()
    {
        if (GameObject.Find("CreatedRoom")== null)
        {
            GameObject gameObject = new GameObject("CreatedRoom");
            gameObject.transform.position = new Vector2(39, 22);

        }
        if (GameObject.Find("RoomCenter")==null)
        {
            GameObject gameObject = new GameObject("RoomCenter");
            gameObject.AddComponent<RoomType>();
            gameObject.AddComponent<BoxCollider2D>();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.transform.position = new Vector2(39.25f, 22.25f);
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.GetComponent<SpriteRenderer>().sprite= CenterSprite;

        }
        cellSize = 0.5f;
        grid = new Grids(200, 200, cellSize, new Vector3(0, 0));
    }


    private void Update()
    {
      grid.GetXY(HandlerClasses.GetMouseWorldPosition(), out int x, out int y);
      mouseDistance= Vector3.Distance(gameObject.transform.position, HandlerClasses.GetMouseWorldPosition());
        
        if (Input.GetMouseButton(0) && mouseDistance > Mathf.Sqrt((cellSize / 2) * (cellSize / 2) + (cellSize / 2) * (cellSize / 2))&& !placedTile.Contains(new Vector3(x, y)))
        {
                MouseHandlerPos(grid.GridPos(x,y).x,grid.GridPos(x,y).y);
                SpawnTile(TilePrefab);
                placedTile.Add(new Vector3(x, y));
        }
        if (Input.GetMouseButton(1))
        {

            MouseHandlerPos(grid.GridPos(x, y).x, grid.GridPos(x, y).y);
            placedTile.Remove(new Vector3(x, y));
            DestroyTile(x,y,  out int qwe,out int  asd);
            placedTile.Remove(new Vector3(qwe, asd));

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("RoomCenter").transform.position = grid.GridPos(GetCenter().x, GetCenter().y);
            GameObject.Find("CreatedRoom").transform.SetParent(GameObject.Find("RoomCenter").transform);
            GameObject.Find("CreatedRoom").name = "TilesParent";
            Destroy(GameObject.Find("RoomCenter").GetComponent<SpriteRenderer>());
            GameObject.Find("RoomCenter").name = RoomName;
            GameObject.Find(RoomName).layer = HandlerClasses.ToLayer(RoomLayer) ;
            

           


            foreach (GameObject parentObj in GameObject.FindGameObjectsWithTag("Tiles"))
            {
                var destroyTiles= parentObj.GetComponentInChildren<IDestroyTiles>();
                destroyTiles.DestroyTiles();
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(HandlerClasses.GetMouseWorldPosition(), EraserSize);
    }


    void MouseHandlerPos(float x, float y)
    {
        gameObject.transform.position = new Vector3(x,y);
    }
    public Vector3 GetGridPos()
    {
        grid.GetXY(HandlerClasses.GetMouseWorldPosition(), out int x, out int y);
        return new Vector3(x, y);

    }
    
    public  void SpawnTile(GameObject tilePrefab)
    {
        GameObject tile = Instantiate(tilePrefab, gameObject.transform.position, Quaternion.identity);
        tile.transform.SetParent(GameObject.Find("CreatedRoom").transform);

    }
    private void DestroyTile(int x, int y,out int outX,out int outY)
    {
        outX = -1;
        outY = -1;
        Collider2D ray = Physics2D.OverlapBox(HandlerClasses.GetMouseWorldPosition(), EraserSize, 360f,TileSpawnpointLayer);
        if (ray != null)
        {
          
            if (ray.gameObject.tag == "Tiles")
            {
                grid.GetXY(ray.gameObject.transform.position, out int xPos, out int yPos);
                Destroy(ray.gameObject);
                outX = xPos;
                outY = yPos;
            }
            ray = null;

        } 
        
    }
    private Vector3 GetCenter()
    {
       
        float maxValueX = 0;
        float minValueX = 9999999;
        float maxValueY = 0;
        float minValueY = 9999999;
        float CenterX = 0;
        float CenterY = 0;
        Vector3 CenterPos = Vector3.zero;
        foreach (Vector3 tilePositions in placedTile)
        {
            if (maxValueX < tilePositions.x)
            {
                maxValueX = tilePositions.x;
            }
            if (minValueX > tilePositions.x)
            {
                minValueX = tilePositions.x;
            }
            if (maxValueY < tilePositions.y)
            {
                maxValueY = tilePositions.y;
            }
            if (minValueY > tilePositions.y)
            {
                minValueY = tilePositions.y;

            }
        }
     
        CenterX = (maxValueX + minValueX) / 2;
        CenterY = (maxValueY + minValueY) / 2;
        

        return new Vector3(CenterX, CenterY);
    }
   
}
