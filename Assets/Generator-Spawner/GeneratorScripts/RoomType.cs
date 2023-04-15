using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;//room type index
    public void RoomDestruction()
    {
        Destroy(gameObject);//destroy room
    }
}
