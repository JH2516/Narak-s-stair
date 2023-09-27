using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    //현제 게임이 진행되고 있는 상태를 정의
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
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0)); //왼쪽을 누르면 캐릭터가 보는 방향 변경 **
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); //오른쪽을 누르면 캐릭터가 보는 복귀 **
                Move();
            }
        }
        
    }

    private void Move()
    {
        //myAnim.SetTrigger("JUMP");
        transform.Translate(new Vector3(1, -1, 0)); //오브젝트의 시점에서 x 1컴마 y -1컴마 이동 **
        if (transform.position.y % 10 == 0) map.CreateMap(); //플레이어의 y축이 10컴마 이동할때마다 CreateMap함수 호출

        // 현재 이동한 위치가 올바른 위치에 이동했는지 검사하기 위한 조건문
        if (transform.localPosition.x != GameObject.Find((--height).ToString()).transform.localPosition.x) 
            //생성된 계단의 위치의 x축값과 플레이어의 x축값이 같이 않다면? "localPosition = 부모오브젝트의 위치"
        {
            state = State.Over; //게임오버
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