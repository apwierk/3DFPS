using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
// ������ �ٰ� �ʹ�. �߷�, �ٴ� ��, �ӵ�
public class PlayerMove : MonoBehaviour
{
    // - ũ��
    public float speed = 5;
    public float gravity = -9.87f;
    public float jumpPower = 10;
    float yVelocity;

    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. y�ӵ��� �߷��� ��� ���ϰ�ʹ�.
        yVelocity += gravity * Time.deltaTime;
        // 2. ���� ����ڰ� ������ư�� ������ y�ӵ��� �ٴ����� �����ϰ�ʹ�.
        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
        


        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. ������ �����
        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        // ī�޶� �ٶ󺸴� ������ �չ������� �ϰ�ʹ�.
        dir = Camera.main.transform.TransformDirection(dir);

        dir.Normalize();
        // 3. y�ӵ��� ���� dir �� y�� �����ϰ�ʹ�
        dir.y = yVelocity;
        // 3. �� �������� �̵��ϰ� �ʹ�.
        cc.Move(dir * speed * Time.deltaTime);
    }
}
