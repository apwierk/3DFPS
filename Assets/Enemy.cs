using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// FSM으로 상태를 제어하고싶다.
// 정지, 이동, 공격, 죽음
public class Enemy : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        Die,
    }

public State state;
    PlayerHP php;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;

        target = GameObject.Find("Player");
        php = target.GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            UpdateIdle();
        } else if (state == State.Move)
        {
            UpdateMove();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
       
    }

    GameObject target;
    public float findDistance = 5;
    private void UpdateIdle()
    {
        // target이 감지거리 안에 들어오면 Move로 전이하고싶다.
        // 1/ 나와 타겟의 거리를 구한다.
        float distance = Vector3.Distance(transform.position, target.transform.position);
        // 2. 만약 극 거리가 감지거리보다 작으면
        if(distance < findDistance)
        {
            // 3. Move상태로 전이하고싶다.
            state = State.Move;
        }


    }


    public float speed = 1;
    public float attackDistance = 1.5f;
    private void UpdateMove()
    {
        // target방향으로 이동하다가 target이 공격거리안에 들어오면 Attack으로 전이하고싶다.
        // 1. target방향으로 구하고싶다.
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        // 2. 나와 target의 거리를 구해서
        float distance = Vector3.Distance(transform.position, target.transform.position);
        // 3. 만약 그 거리가 공격거리보다 작으면
        if(distance < attackDistance)
        {
            // 4. Attack상태로 전이하고싶다.
            state = State.Attack;
        }

    }


    float currentTime;
    float attackTime = 1;
    private void UpdateAttack()
    {
        // 일정시간마다 공격을 하되 공격시점에 target이 공격거리 밖에 있으면 Move상태로 전이하고싶다. 그렇지않으면 계속 반복해서 공격
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 현재시간이 공격시간이 되면
        if (currentTime > attackTime)
        {
            // 3. 현재시간이 초기화하고
            currentTime = 0;
            
            // 5. 만약 target이 공격거리 밖에 있으면 Move상태로 전이하고싶다.
            // 5-1. 나와 target의 거리를 구해서
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // 5-2. 만약 그 거리가 공격거리보다 크다면
            if (distance > attackDistance)
            {
                //공격실패
                // 5-3. Move상태로 전이하고싶다.
                state = State.Move;
            }
            else
            {
                // 공격 성공
                // 4. 플레이어를 공격하고
                php.AddDamage();
                // target.AddDamage();
                // HitManager 의 Hit함수를 호출하고싶다.
                HitManager.instance.Hit();
            }



        }
    }

   public void AddDamage(int damage)
    {
        Destroy(gameObject);
    }
}
