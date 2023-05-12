using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    bool coroutineBool = false;

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
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightMove");
            }
            offset.y = 0;
            transform.position = player.transform.position - offset;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 180; turn++)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
