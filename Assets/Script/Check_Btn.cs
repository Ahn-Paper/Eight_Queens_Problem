using UnityEngine;
using UnityEngine.Tilemaps;

public class Check_Btn : MonoBehaviour
{
    public Touch_Screen touchScreen;
    public Tilemap highlightTilemap;

    public int[,] Path = new int[8, 8]; //���� ��� �迭

    public bool toggle = false; //��ư ��� ���

    void Awake() //Tilemap ����ȭ
    {
        highlightTilemap.gameObject.SetActive(true);
        Path_Visual(); //�ʱ� Path[x, y] ���� �����Ƿ� ��� Ÿ�� Color(0f, 0f, 0f, 0f)�� ������
    }

    public void OnCheck()
    {
        if(toggle) //����� true�� �� ��ư�� ���� �� ���� �ʱ�ȭ �� ��� false 
        {
            Path_Reset();
            Path_Visual();
            toggle = false;
        }
        else //����� false�� �� ��ư�� ���� �� ��� ���� ǥ�� �� ��� true 
        {
            Path_func();
            toggle = true;
        }
        
    }

    public void Path_func() //��� ���� ǥ�� �Լ� ����
    {
        Path_Reset();
        Path_CalAttack();
        Path_Visual();
    }

    void Path_Reset() //��� �迭 �ʱ�ȭ
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Path[x, y] = 0;
            }
        }
    }

    void Path_CalAttack() //�� ���� ��� ���
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (touchScreen.area[x, y] != null)
                {
                    Path[x, y] = 100; //�� ��ǥ ǥ��
                    
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0) continue; //���ڸ� ����

                            int nx = x, ny = y;
                            while (true)
                            {
                                nx += dx;
                                ny += dy;

                                if (nx < 0 || nx >= 8 || ny < 0 || ny >= 8) //��� ���� ü���� ���� ����
                                    break;

                                if (touchScreen.area[nx, ny] != null)// ���� ��ο� �� ����
                                {                                    
                                    Attack_Line(x, y, nx, ny, dx, dy);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    void Attack_Line(int sx, int sy, int ex, int ey, int dx, int dy) //start �� ��ǥ, end �� ��ǥ, ���� ��ǥ
    {
        int nx = sx + dx, ny = sy + dy;
        while (nx != ex || ny != ey)
        {
            Path[nx, ny] = 200; // ���� ���� ����
            nx += dx;
            ny += dy;
        }
        Path[sx, sy] = 200;
        Path[ex, ey] = 200;
    }

    void Path_Visual() //�� ���� ��� ǥ��
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);

                Color color;

                if (Path[x, y] == 200)
                    color = new Color(1f, 0f, 0f, 1f);
                else if (Path[x, y] == 100)
                    color = new Color(0f, 1f, 0f, 1f);
                else
                    color = new Color(0f, 0f, 0f, 0f);

                highlightTilemap.SetColor(tilePos, color);
            }
        }
    }
}
