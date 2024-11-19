using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Point;
    public float PlayTime;           // 블록이 모두 떨어지기까지 걸리는 시간 측정
    public bool GameOver = false;    // 블록이 모두 떨어졌는지 체크하기

    public Text Text_PlayTime;       // 게임 플레이 시간 텍스트 저장
    public Text Text_GetPoint; // 맞춘 표적 갯수 텍스트 저장

    public int minutes, seconds;     // 분초 단위 시간 측정

    public GameObject ClearGUI;
    public GameObject Aim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
        Aim.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Aim.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Aim.SetActive(false);
        }

        // 끝나지 않은 상태라면 계속 시간을 더함
        if (GameOver == false)
        {
            PlayTime += Time.deltaTime;
        }
        if (Point >= 5)
        {
            GameOver = true;
        }

        // 게임이 끝났을 경우  
        if (GameOver == true && Point >= 5)
        {
            ClearGUI.SetActive(true);
            Aim.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }


        seconds = (int)(PlayTime % 60f); // 초 단위 표시
        minutes = (int)((PlayTime / 60f) % 60f); // 분 단위 표시

        // Text_PlayTime 컴포넌트의 text변수에 "문자열" 및 측정된 시간을 표시
        //Text_PlayTime.text = "Timer: " + PlayTime.ToString("00");
        Text_PlayTime.text = minutes.ToString("00") +
                             ":" + seconds.ToString("00");

        // Text_FallinBoxCount 컴포넌트의 text변수에 "문자열" 및 맞춘 표적 갯수 표시
        Text_GetPoint.text = "x " + Point.ToString("00");
    }
}
