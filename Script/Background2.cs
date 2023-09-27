using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2 : MonoBehaviour
{
    public float bgspeed = 0.05f;
    public GameObject camera;
    Vector2 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(Time.time * bgspeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        gameObject.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 1);
    }
}