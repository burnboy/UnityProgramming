using Photon.Pun;//유니티용 포톤 컴포넌트
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

//마스터(매치메이킹) 서버와 룸 접속 담당
public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";//게임 버전

    public Text connectionInfoText;// 네트워크 정보를 표시할 텍스트
    public Button joinButton;//룸접속버튼

    //게임실행과 동시에 마스터서버 접속 시도
    private void Start()
    {
        
    }

    //마스터 서버 접속 성공시 자동실행
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
    }

    //마스터서버 접속 실패시 자동실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        //base.OnDisconnected(cause);
    }

    //룸 접속 시도
    public void Connect()
    {
        
    }

    //빈방이없어서 랜덤룸 참가에 자동실패한 경우 자동실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //base.OnJoinRandomFailed(returnCode, message);
    }

    //룸에 참가완료된 경우 자동실행
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
