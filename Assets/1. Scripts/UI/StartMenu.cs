using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclicked(int type) {
        switch(type)
        {
            case 0:
                // print("본게임 실행");
                break;
            case 1:
                // print("세팅 설정 실행");
                break;
            case 2:
                // print("튜토리얼 실행");
                break;
            case 3:
                // print("게임 종료 실행");
                break;
        }
        // print("I am clicked.");
    }
}
