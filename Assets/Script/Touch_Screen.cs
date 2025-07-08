using UnityEngine;

public class Touch_Screen : MonoBehaviour
{
    public GameObject queen;
    public Check_Btn checkBtn;
    public Toast toast;

    public Vector3 point; //��ġ(Ŭ��) ��ǥ
    public GameObject[,] area = new GameObject[8, 8]; //ü���� ��ǥ �� �� ���� Ȯ�ο� �迭

    public int count = 0; //�� ���� ī���� ����

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //���콺 Ŭ�� ��
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition); //�ش� ��ǥ point�� ����
            point.z = 0f;
            Vector2Int gridPos;

            if (Function_GetPos(point, out gridPos))
            {
                if (area[gridPos.x, gridPos.y] == null)//ü���ǿ� ���� ���� ��
                {
                    if (count < 8)
                        Function_Instantiate(gridPos.x, gridPos.y);
                    else
                        toast.ShowToast("�� �̻� ���� ���� �� �����ϴ�.");
                }
                else //ü���ǿ� ���� ���� ��
                    Function_Destroy(gridPos.x, gridPos.y);
            }

        }
    }

    public bool Function_GetPos(Vector3 worldPos, out Vector2Int gridPos) //ü���� ��ǥ ��� �Լ�
    {
        int gridX = Mathf.FloorToInt(worldPos.x);
        int gridY = Mathf.FloorToInt(worldPos.y);

        if (gridX >= 0 && gridX < 8 && gridY >= 0 && gridY < 8) //ü���� ���� Ŭ�� �� ��ǥ�� true ��ȯ
        {
            gridPos = new Vector2Int(gridX, gridY);
            return true;
        }
        else //ü���� �ܺ� Ŭ�� �� false ��ȯ �� ��ǥ �ʱ�ȭ
        {
            gridPos = Vector2Int.zero;
            return false;
        }
    }

    void Function_Instantiate(int x, int y) //�� ���� �Լ�
    {
        Vector3 spawn_point = new Vector3(x + 0.5f, y + 0.5f, 0f);
        GameObject newQueen = Instantiate(queen, spawn_point, Quaternion.identity);
        area[x, y] = newQueen;
        count++;
        if (checkBtn != null && checkBtn.toggle)
            checkBtn.Path_func();
    }

    void Function_Destroy(int x, int y) //�� ���� �Լ�
    {        
        Destroy(area[x, y]);
        area[x, y] = null;
        count--;
        if (checkBtn != null && checkBtn.toggle)
            checkBtn.Path_func();
    }

    public void Reset_Board()         // ü���� �ʱ�ȭ �Լ�
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (area[x, y] != null)
                {
                    Destroy(area[x, y]);
                    area[x, y] = null;
                    count = 0;
                }
            }
        }
        if (checkBtn != null && checkBtn.toggle)
            checkBtn.Path_func();
        toast.ShowToast("ü���� �ʱ�ȭ");
    }
}


