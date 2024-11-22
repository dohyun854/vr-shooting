using UnityEngine;
using UnityEngine.UI;

public class show_ranking : MonoBehaviour
{
    public Text RankNameCurrent; // 현재 플레이어 이름 텍스트
    public Text[] RankScoreText; // 점수 텍스트 배열
    public Text[] RankNameText; // 이름 텍스트 배열
    public Text[] RankText; // 랭킹 표시 텍스트 배열

    private float[] rankScore = new float[5]; // 상위 5명의 점수 저장
    private string[] rankName = new string[5]; // 상위 5명의 이름 저장

    // Start is called before the first frame update
    void Start()
    {
        // 현재 플레이어 이름과 점수 표시
        RankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName", "Unknown");
        RankNameCurrent.text = string.Format("{0:N1}cm", PlayerPrefs.GetFloat("CurrentPlayerScore", 0f));

        for (int i = 0; i < 5; i++)
        {
            // PlayerPrefs에서 데이터 가져오기
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore", 0f);
            rankName[i] = PlayerPrefs.GetString(i + "BestName", "Unknown");

            // UI에 데이터 적용
            RankScoreText[i].text = string.Format("{0:N1}cm", rankScore[i]);
            RankNameText[i].text = rankName[i];

            // 현재 플레이어가 순위에 있을 경우 하이라이트
            if (RankNameCurrent.text == RankScoreText[i].text)
            {
                Color highlightColor = new Color(1f, 1f, 0f); // 노란색 (RGB 범위: 0~1)
                RankText[i].color = highlightColor;
                RankNameText[i].color = highlightColor;
                RankScoreText[i].color = highlightColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 업데이트 로직이 필요하면 작성
    }
}
