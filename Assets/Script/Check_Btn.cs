using UnityEngine;
using UnityEngine.Tilemaps;

public class Check_Btn : MonoBehaviour
{
    public Touch_Screen touchScreen;
    public Tilemap highlightTilemap;

    public int[,] Path = new int[8, 8]; //공격 경로 배열

    public bool toggle = false; //버튼 토글 기능

    void Awake() //Tilemap 투명화
    {
        highlightTilemap.gameObject.SetActive(true);
        Path_Visual(); //초기 Path[x, y] 값은 없으므로 모든 타일 Color(0f, 0f, 0f, 0f)로 지정됨
    }

    public void OnCheck()
    {
        if(toggle) //토글이 true일 때 버튼을 누를 시 색상 초기화 후 토글 false 
        {
            Path_Reset();
            Path_Visual();
            toggle = false;
        }
        else //토글이 false일 때 버튼을 누를 시 경로 색상 표시 후 토글 true 
        {
            Path_func();
            toggle = true;
        }
        
    }

    public void Path_func() //경로 색상 표시 함수 묶음
    {
        Path_Reset();
        Path_CalAttack();
        Path_Visual();
    }

    void Path_Reset() //경로 배열 초기화
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Path[x, y] = 0;
            }
        }
    }

    void Path_CalAttack() //퀸 공격 경로 계산
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (touchScreen.area[x, y] != null)
                {
                    Path[x, y] = 100; //퀸 좌표 표시
                    
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0) continue; //제자리 제외

                            int nx = x, ny = y;
                            while (true)
                            {
                                nx += dx;
                                ny += dy;

                                if (nx < 0 || nx >= 8 || ny < 0 || ny >= 8) //계산 범위 체스판 내로 제한
                                    break;

                                if (touchScreen.area[nx, ny] != null)// 공격 경로에 퀸 존재
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
    
    void Attack_Line(int sx, int sy, int ex, int ey, int dx, int dy) //start 퀸 좌표, end 퀸 좌표, 방향 좌표
    {
        int nx = sx + dx, ny = sy + dy;
        while (nx != ex || ny != ey)
        {
            Path[nx, ny] = 200; // 공격 관계 라인
            nx += dx;
            ny += dy;
        }
        Path[sx, sy] = 200;
        Path[ex, ey] = 200;
    }

    void Path_Visual() //퀸 공격 경로 표시
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
