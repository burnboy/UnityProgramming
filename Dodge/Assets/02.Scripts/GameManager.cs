using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI관련 라이브러리
using UnityEngine.SceneManagement;  //씬 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;     //게임오버시 활성화할 텍스트 게임오브젝트
    public Text timeText;               // 생존시간을 표시할 텍스트 컴포넌트
    public Text recordText;             //최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime;      //생존시간
    private bool isGameOver;        //게임오버 상태



    // Start is called before the first frame update
    void Start()
    {
        //생존시간과 게임오버상태 초기화
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 이닌 동안
        if (!isGameOver)
        {
            //생존시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존시간을 TimeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            //게임오버 상태에서 R 키를 누른경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    //현재 게임을 게임오버상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameOver = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        gameOverText.SetActive(true);

        //bestTime 키로 저장된 이전까지의 최고기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고기록보다 현재 생존시간이 길다면
        if (surviveTime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTme키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 recordText텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }

}
