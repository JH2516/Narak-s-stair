using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{

    private Transform target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.y < transform.position.y - 10) Destroy(gameObject);
        //플레이어의 y축값이 -11이라면 y값이 -1인 계단을 재거
    }
}