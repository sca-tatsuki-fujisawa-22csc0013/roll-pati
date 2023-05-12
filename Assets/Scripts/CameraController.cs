using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < 13)
        {
            if(transform.rotation.y < 180)
            {
                for (int i = 0; i < 180; i++)
                {
                    transform.Rotate(new Vector3(0, i, 0) * Time.deltaTime);
                }
                return;
            }
            
            transform.position = player.transform.position - offset;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
