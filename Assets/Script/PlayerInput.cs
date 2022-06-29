using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const string XAxis = "Horizontal";
    public const string ZAxis = "Vertical";
    public const string ShootButton = "Fire1";
    public const string YAxis = "Jump";

    //��: -1,����:0,  ��: 1
    public float XAxisDir { get; private set; }
    //�Ʒ�: -1,����:0,  ��: 1
    public float ZAxisDir { get; private set; }
    //���콺 ��Ŭ���� 1(true), 0(false)
    public bool IsShootingButton { get; private set; }
    //�����̽��� ���� 1(true), 0(false)
    public bool YAxisDir { get; private set; }


    void Update()
    {
        XAxisDir = Input.GetAxis(XAxis);
        ZAxisDir = Input.GetAxis(ZAxis);
        IsShootingButton = Input.GetButtonDown(ShootButton);
        YAxisDir = Input.GetButtonDown(YAxis);
    }
}
