using UnityEngine;
using UnityEngine.UI;

public class show_ranking : MonoBehaviour
{
    public Text RankNameCurrent; // ���� �÷��̾� �̸� �ؽ�Ʈ
    public Text[] RankScoreText; // ���� �ؽ�Ʈ �迭
    public Text[] RankNameText; // �̸� �ؽ�Ʈ �迭
    public Text[] RankText; // ��ŷ ǥ�� �ؽ�Ʈ �迭

    private float[] rankScore = new float[5]; // ���� 5���� ���� ����
    private string[] rankName = new string[5]; // ���� 5���� �̸� ����

    // Start is called before the first frame update
    void Start()
    {
        // ���� �÷��̾� �̸��� ���� ǥ��
        RankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName", "Unknown");
        RankNameCurrent.text = string.Format("{0:N1}cm", PlayerPrefs.GetFloat("CurrentPlayerScore", 0f));

        for (int i = 0; i < 5; i++)
        {
            // PlayerPrefs���� ������ ��������
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore", 0f);
            rankName[i] = PlayerPrefs.GetString(i + "BestName", "Unknown");

            // UI�� ������ ����
            RankScoreText[i].text = string.Format("{0:N1}cm", rankScore[i]);
            RankNameText[i].text = rankName[i];

            // ���� �÷��̾ ������ ���� ��� ���̶���Ʈ
            if (RankNameCurrent.text == RankScoreText[i].text)
            {
                Color highlightColor = new Color(1f, 1f, 0f); // ����� (RGB ����: 0~1)
                RankText[i].color = highlightColor;
                RankNameText[i].color = highlightColor;
                RankScoreText[i].color = highlightColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ������Ʈ ������ �ʿ��ϸ� �ۼ�
    }
}
