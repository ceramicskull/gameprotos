using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float offset;
    void Start()
    {
        offset = transform.position.y - player.transform.position.y;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, transform.position.z);
    }
}
