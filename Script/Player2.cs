using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    //���� ������ ����ǰ� �ִ� ���¸� ����
    public enum State
    {
        Over, Ready, Play
    }

    public Map2 map;
    public State state;
    public GameObject StartBt;
    public GameObject ReStartBt;

    private UI2 ui;
    private Animator myAnim;
    private int height = 0;
    bool Run;

    void Start()
    {
        map = GameObject.FindGameObjectWithTag("map").GetComponent<Map2>();
        ui = GameObject.Find("GameManager").GetComponent<UI2>();
        myAnim = GetComponent<Animator>();
        state = State.Ready;
        ReStartBt.SetActive(false);
        Run = true; 
}

    void Update()
    {
        if (state == State.Over)
        {
            //    if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("SampleScene");
            //    return;
            Run = false;
            ReStartBt.SetActive(true);
        }
        if (state == State.Play) ui.DecreaseHp();

        if (Run)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (state == State.Ready) state = State.Play;
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0)); //������ ������ ĳ���Ͱ� ���� ���� ���� **
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); //�������� ������ ĳ���Ͱ� ���� ���� **
                Move();
            }
        }
        
    }

    private void Move()
    {
        //myAnim.SetTrigger("JUMP");
        transform.Translate(new Vector3(1, -1, 0)); //������Ʈ�� �������� x 1�ĸ� y -1�ĸ� �̵� **
        if (transform.position.y % 10 == 0) map.CreateMap(); //�÷��̾��� y���� 10�ĸ� �̵��Ҷ����� CreateMap�Լ� ȣ��

        // ���� �̵��� ��ġ�� �ùٸ� ��ġ�� �̵��ߴ��� �˻��ϱ� ���� ���ǹ�
        if (transform.localPosition.x != GameObject.Find((--height).ToString()).transform.localPosition.x) 
            //������ ����� ��ġ�� x�ప�� �÷��̾��� x�ప�� ���� �ʴٸ�? "localPosition = �θ������Ʈ�� ��ġ"
        {
            state = State.Over; //���ӿ���
            //myAnim.SetTrigger("DEAD");
        }
        ui.UpdateScore(height);
        ui.IncreaseHP();
    }

    public void gameStart()
    {
        StartBt.SetActive(false);
        Run = true;
    }
    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
        state = State.Ready;
        ReStartBt.SetActive(false);
    }
}