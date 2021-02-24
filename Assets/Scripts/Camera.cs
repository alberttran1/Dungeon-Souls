using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float cameraOffset = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
        transform.position += (new Vector3((Input.mousePosition.x / Screen.width) - 0.5f,(Input.mousePosition.y / Screen.height) - 0.5f, 0))*cameraOffset;
        Debug.Log(Input.mousePosition.x);
    }
}
