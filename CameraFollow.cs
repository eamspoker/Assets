using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // From Tom Corbett's Understanding Game Engines Course
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = transform.position;

        cameraPosition.x = Mathf.SmoothDamp(cameraPosition.x, playerPosition.x, ref xVelocity, 0.7f);
        cameraPosition.y = Mathf.SmoothDamp(cameraPosition.y, playerPosition.y, ref yVelocity, 0.7f);

        transform.position = cameraPosition;
        
    }
}
