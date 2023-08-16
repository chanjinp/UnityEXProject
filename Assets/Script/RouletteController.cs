using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RouletteController : MonoBehaviour
{
    private float rotSpeed = 0f; // 초기 회전 속도
    [SerializeField] private float rotSpeedSet = 10f;
    void Start()
    {
        // 프레임레이트를 60으로 고정한다
        Application.targetFrameRate = 60;
        
    }
    
    void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (wheelInput < 0) //휠을 아래로로 내렸을 때 세팅 값 -
        {
            rotSpeedSet -= 1f;
            Debug.Log("Minus: "+rotSpeedSet);
        }
        else if (wheelInput > 0) //휠을 위로로 올렸을 때 세팅 값 +
        {
            rotSpeedSet += 1f;
            Debug.Log("Plus: "+rotSpeedSet);
        }
        //음수 값이 된다면 초기화
        if(rotSpeedSet < 5f)
        {
            rotSpeedSet = 10f;
        }
        // 클릭하면 회전 속도를 설정한다
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = rotSpeedSet;
        }
        
        // 회전 속도만큼 룰렛을 회전시킨다
        transform.Rotate(0, 0, this.rotSpeed);
        //룰렛은 z축 기준으로 돌기 때문에 인자가 z축 위치에 들어간다.

        // 룰렛을 감속시킨다(추가)
        this.rotSpeed *= 0.96f;
    }
}
