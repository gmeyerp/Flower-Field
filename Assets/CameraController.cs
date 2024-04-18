using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.05f);        
    }
}
