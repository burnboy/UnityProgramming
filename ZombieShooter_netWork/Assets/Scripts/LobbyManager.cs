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
        //접속에 필요한 정보(게임버전) 설정
        PhotonNetwork.GameVersion = gameVersion;
        //설정한 정보로 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        //룸접속 버튼 잠시 비활성화
        joinButton.interactable = false;
        //접속시도 중임을 텍스트로 표시
        connectionInfoText.text = "마스터서버 접속중...";
        
    }

    //마스터 서버 접속 성공시 자동실행
    public override void OnConnectedToMaster()
    {
        //룸접속 버튼 활성화
        joinButton.interactable = true;
        //접속정보 표시
        connectionInfoText.text = "마스터 서버 연결됨";
        //base.OnConnectedToMaster();
    }

    //마스터서버 접속 실패시 자동실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        //룸접속버튼 비활성화
        joinButton.interactable = false;
        //접속정보 표시
        connectionInfoText.text = "오프라인:마스터서버와 연결X \n재시도 중...";

        //마스터 서버로의 재접속 시도 
        PhotonNetwork.ConnectUsingSettings();
        //base.OnDisconnected(cause);
    }

    //룸 접속 시도
    public void Connect()
    {
        //중복 접속 시도를 막기위해 접속 버튼 잠시 비활성화
        joinButton.interactable = false;

        //마스터 서버에 접속중이라면
        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionInfoText.text = "룸 접속...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인:마스터 서버와 연결되지않음\n 접속 재시도중...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    //빈방이없어서 랜덤룸 참가에 자동실패한 경우 자동실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //접속상태 표시
        connectionInfoText.text = "빈방이 없음,새로운방 생성...";
        //최대 4명을 수용가능한 빈방생성
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });


        //base.OnJoinRandomFailed(returnCode, message);
    }

    //룸에 참가완료된 경우 자동실행
    public override void OnJoinedRoom()
    {
        //접속상태 표시
        connectionInfoText.text = "방 참가 성공";
        //모든 룸 참가자가 Main씬을 로드하게 함
        PhotonNetwork.LoadLevel("Main");
        //base.OnJoinedRoom();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
