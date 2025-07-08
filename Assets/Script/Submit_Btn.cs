using UnityEngine;

public class Submit_Btn : MonoBehaviour   
{
    public Touch_Screen touchScreen;
    public PopUp_Panel popPanel;
    public Check_Btn checkBtn;
    public Toast toast;
    public Audio_Manager audioManager;

    public void OnSubmit() //��ư Ŭ��
    {
        int count;

        if (Check_Clear(out count))
        {
            Show_AttackPath();
            audioManager.Submit_correct();
            popPanel.Show_Message("Ŭ����!");
        }
        else if (count == 8)
        {
            Show_AttackPath();
            audioManager.Submit_wrong();
            popPanel.Show_Message("Ʋ�Ƚ��ϴ�.");
        }
        else
        {
            toast.ShowToast("���� �����մϴ�.");
        }
    }

    private void Show_AttackPath()
    {
        if (!checkBtn.toggle)
        {
            checkBtn.Path_func();
            checkBtn.toggle = true;
        }
    }

    bool Check_Clear(out int count) //���� Ȯ�� ����
    {
        count = 0;

        Vector2Int[] QueenPos = new Vector2Int[8];

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (touchScreen.area[x, y] != null)
                {
                    QueenPos[count] = new Vector2Int(x, y);
                    count++;
                }
            }
        }

        if (count == 8) 
        {
            for (int i = 0; i < 8; i++) // �� ���� ���� Ȯ��
            {
                Vector2Int q1 = QueenPos[i];

                for (int j = i + 1; j < 8; j++)
                {
                    Vector2Int q2 = QueenPos[j];

                    if (q1.x == q2.x)
                        return false;

                    if (q1.y == q2.y)
                        return false;

                    if (Mathf.Abs(q1.x - q2.x) == Mathf.Abs(q1.y - q2.y))
                        return false;
                }
            }
            return true;
        }
        else
            return false;
  
    }
}
