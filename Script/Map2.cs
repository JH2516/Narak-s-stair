using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{
    public GameObject platform;	//����
    private int cnt = 0;	// ������ ������Ʈ�� y��ǥ�� �����ϱ� ���� ��
    private int x = 0;  // ������ ������Ʈ�� x��ǥ�� �����ϱ� ���� ��

    // ���� ���۽� �� ����
    void Start()
    {
        CreateMap();
    }

    //�� ������ ���� �ڵ�
    public void CreateMap()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject gobj = Instantiate(platform);
            // Random ��ü�� �̿��ؼ� �������� x��ǥ�� �����ϰų� �����Ѵ�.
            if (Random.Range(0, 2) == 0)
            {
                x++;
            }
            else
            {
                x--;
            }
            gobj.transform.position = new Vector3(x, (--cnt), 0);
            //������ ������Ʈ�� �����ϱ� ���� cnt�� ���� �־���.
            gobj.name = cnt.ToString();
        }
    }
}