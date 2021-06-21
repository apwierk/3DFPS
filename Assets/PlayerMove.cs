using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 사용자의 입력에 따라 앞뒤좌우로 이동하고 싶다.
// 점프를 뛰고 싶다. 중력, 뛰는 힘, 속도
public class PlayerMove : MonoBehaviour
{
    // - 크기
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
        // 1. y속도에 중력을 계속 더하고싶다.
        yVelocity += gravity * Time.deltaTime;
        // 2. 만약 사용자가 점프버튼을 누르면 y속도에 뛰는힘을 대입하고싶다.
        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
        


        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. 방향을 만들고
        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        // 카메라가 바라보는 방향을 앞방향으로 하고싶다.
        dir = Camera.main.transform.TransformDirection(dir);

        dir.Normalize();
        // 3. y속도를 최종 dir 의 y에 대입하고싶다
        dir.y = yVelocity;
        // 3. 그 방향으로 이동하고 싶다.
        cc.Move(dir * speed * Time.deltaTime);
    }
}
