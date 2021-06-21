using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// FSM���� ���¸� �����ϰ�ʹ�.
// ����, �̵�, ����, ����
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
        // target�� �����Ÿ� �ȿ� ������ Move�� �����ϰ�ʹ�.
        // 1/ ���� Ÿ���� �Ÿ��� ���Ѵ�.
        float distance = Vector3.Distance(transform.position, target.transform.position);
        // 2. ���� �� �Ÿ��� �����Ÿ����� ������
        if(distance < findDistance)
        {
            // 3. Move���·� �����ϰ�ʹ�.
            state = State.Move;
        }


    }


    public float speed = 1;
    public float attackDistance = 1.5f;
    private void UpdateMove()
    {
        // target�������� �̵��ϴٰ� target�� ���ݰŸ��ȿ� ������ Attack���� �����ϰ�ʹ�.
        // 1. target�������� ���ϰ�ʹ�.
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        // 2. ���� target�� �Ÿ��� ���ؼ�
        float distance = Vector3.Distance(transform.position, target.transform.position);
        // 3. ���� �� �Ÿ��� ���ݰŸ����� ������
        if(distance < attackDistance)
        {
            // 4. Attack���·� �����ϰ�ʹ�.
            state = State.Attack;
        }

    }


    float currentTime;
    float attackTime = 1;
    private void UpdateAttack()
    {
        // �����ð����� ������ �ϵ� ���ݽ����� target�� ���ݰŸ� �ۿ� ������ Move���·� �����ϰ�ʹ�. �׷��������� ��� �ݺ��ؼ� ����
        // 1. �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;
        // 2. ����ð��� ���ݽð��� �Ǹ�
        if (currentTime > attackTime)
        {
            // 3. ����ð��� �ʱ�ȭ�ϰ�
            currentTime = 0;
            
            // 5. ���� target�� ���ݰŸ� �ۿ� ������ Move���·� �����ϰ�ʹ�.
            // 5-1. ���� target�� �Ÿ��� ���ؼ�
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // 5-2. ���� �� �Ÿ��� ���ݰŸ����� ũ�ٸ�
            if (distance > attackDistance)
            {
                //���ݽ���
                // 5-3. Move���·� �����ϰ�ʹ�.
                state = State.Move;
            }
            else
            {
                // ���� ����
                // 4. �÷��̾ �����ϰ�
                php.AddDamage();
                // target.AddDamage();
                // HitManager �� Hit�Լ��� ȣ���ϰ�ʹ�.
                HitManager.instance.Hit();
            }



        }
    }

   public void AddDamage(int damage)
    {
        Destroy(gameObject);
    }
}
