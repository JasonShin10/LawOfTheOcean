using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector3 initialRotation;
    
    [SerializeField] private float speed = 2;
    public float Speed
    {
        get { return speed; }
        set
        {
            speed = value;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Quaternion quaternion = Quaternion.identity;
        quaternion.eulerAngles = initialRotation;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        // �÷��̾ �Է¹޴� �������� �����϶�
        // ���� ���װ��� �����Ѵ�.
        float x = playerInput.XAxisDir;
        float z = playerInput.ZAxisDir;
        
        Vector3 dir = new Vector3(x, 0, z);
        Vector3 cdir = Camera.main.transform.TransformDirection(dir).normalized;
        GetComponent<Rigidbody>().AddForce(cdir * speed);
        //if ( x < 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(moveForward + moveRight);
        //}
        ////if (x == 0 && speed >= 0)
        ////{
        ////    speed -= Time.deltaTime;
            
        ////}
        //print(speed);
        //if ( x > 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(moveForward);
        //}
        //if ( z < 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(-moveRight);
        //}
        //if (z > 0)
        //{
        //    GetComponent<Rigidbody>().AddRelativeForce(moveRight);
        //}
        // ���� �Է��� �Ǹ� ( x���� 0���� Ŀ���ٸ�) speed���� ������Ų��.
        // speed ���� �����Ǹ鼭 �ӵ��� ��������.
        // speed �� -�� ���� +�� ������
        // ���� x�� 0�̸� �����.
        // if (x == -1)
        // {
        //     adSpeed -= Time.deltaTime;
        // }
        //if ( x == 0)
        // {
        //     adSpeed = Mathf.Lerp(adSpeed, 0, Time.deltaTime);
        // }
        // if (x == 1)
        // {
        //     adSpeed += Time.deltaTime;
        // }
        // if (x != 0)
        // {
        // }


       // dir = Vector3.right * x + Vector3.forward * z;
       //    dir.Normalize();
       //    dir = Camera.main.transform.TransformDirection(dir);
       //transform.position += dir * speed * Time.deltaTime;
    }

}
