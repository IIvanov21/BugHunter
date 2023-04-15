using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float frequency;
    public float amplitude;
 
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, (Mathf.Sin(Time.time* frequency) * amplitude)+gameObject.transform.position.y, gameObject.transform.position.z); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Playermain"))
        {
            
            gameObject.GetComponent<Collider2D>().enabled = false;
            Invoke("DestroyDelay", 0.2f);

        }
    }
    void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
