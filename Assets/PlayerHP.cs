using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// 태어날 때 체력을 최대체력으로 하고싶다.
// 적이 플레이어를 공격할 때 체력을 감소시키고 싶다.
// 체력이 변경되면 UI에도 반영 하고싶다.

public class PlayerHP : MonoBehaviour
{
    int hp;
    public int maxHP = 3;
    public Slider sliderHP;


    // property (함수인데 변수처럼 사용가능)
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
