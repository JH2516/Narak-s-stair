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
        //�÷��̾��� y�ప�� -11�̶�� y���� -1�� ����� ���
    }
}