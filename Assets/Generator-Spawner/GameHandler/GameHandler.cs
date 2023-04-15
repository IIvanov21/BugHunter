using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

	[SerializeField]private CameraFollow cameraFollow;
	private Vector3 cameraPosition;
	private float orthoSize = 23.54338f;

	private void Start()
	{

		cameraPosition = cameraFollow.gameObject.transform.position;
		cameraFollow.Setup(() => cameraPosition, () => orthoSize, true, false);
	}

	private void Update()
	{
		float cameraSpeed = 0.15f;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			cameraPosition += new Vector3(-1, 0) * cameraSpeed;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			cameraPosition += new Vector3(+1, 0) * cameraSpeed;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			cameraPosition += new Vector3(0, +1) * cameraSpeed;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			cameraPosition += new Vector3(0, -1) * cameraSpeed;
		}
		
		
			if (Input.mouseScrollDelta.y>-0.1f&& orthoSize >= 2)
			{
				orthoSize -= 3f;
			}
		
			if (Input.mouseScrollDelta.y < 0.1f && orthoSize<=100)
			{
				orthoSize += 3f;
			}
		
	}

}
