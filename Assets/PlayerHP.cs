using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// �¾ �� ü���� �ִ�ü������ �ϰ�ʹ�.
// ���� �÷��̾ ������ �� ü���� ���ҽ�Ű�� �ʹ�.
// ü���� ����Ǹ� UI���� �ݿ� �ϰ�ʹ�.

public class PlayerHP : MonoBehaviour
{
    int hp;
    public int maxHP = 3;
    public Slider sliderHP;


    // property (�Լ��ε� ����ó�� ��밡��)
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderHP.value = value;
        }
    }
 
    public void AddDamage()
    {
        HP = HP - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        sliderHP.maxValue = maxHP;
    HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
