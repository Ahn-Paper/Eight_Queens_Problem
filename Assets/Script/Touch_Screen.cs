using UnityEngine;

public class Touch_Screen : MonoBehaviour
{
    public GameObject queen;
    public Check_Btn checkBtn;
    public Toast toast;

    public Vector3 point; //터치(클릭) 좌표
    public GameObject[,] area = new GameObject[8, 8]; //체스판 좌표 및 퀸 생성 확인용 배열

    public int count = 0; //퀸 개수 카운팅 변수

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //마우스 클릭 시
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition); //해당 좌표 point에 저장
            point.z = 0f;
            Vector2Int gridPos;

            if (Function_GetPos(point, out gridPos))
            {
                if (area[gridPos.x, gridPos.y] == null)//체스판에 퀸이 없을 시
                {
                    if (count < 8)
                        Function_Instantiate(gridPos.x, gridPos.y);
                    else
                        toast.ShowToast("더 이상 퀸을 놓을 수 없습니다.");
                }
                else //체스판에 퀸이 있을 시
                    Function_Destroy(gridPos.x, gridPos.y);
            }

        }
    }

    public bool Function_GetPos(Vector3 worldPos, out Vector2Int gridPos) //체스판 좌표 계산 함수
    {
        int gridX = Mathf.FloorToInt(worldPos.x);
        int gridY = Mathf.FloorToInt(worldPos.y);

        if (gridX >= 0 && gridX < 8 && gridY >= 0 && gridY < 8) //체스판 내부 클릭 시 좌표와 true 반환
        {
            gridPos = new Vector2Int(gridX, gridY);
            return true;
        }
        else //체스판 외부 클릭 시 false 반환 및 좌표 초기화
        {
            gridPos = Vector2Int.zero;
            return false;
        }
    }

    void Function_Instantiate(int x, int y) //퀸 생성 함수
    {
        Vector3 spawn_point = new Vector3(x + 0.5f, y + 0.5f, 0f);
        GameObject newQueen = Instantiate(queen, spawn_point, Quaternion.identity);
        area[x, y] = newQueen;
        count++;
        if (checkBtn != null && checkBtn.toggle)
            checkBtn.Path_func();
    }

    void Function_Destroy(int x, int y) //퀸 제거 함수
    {        
        Destroy(area[x, y]);
        area[x, y] = null;
        count--;
        if (checkBtn != null && checkBtn.toggle)
            checkBtn.Path_func();
    }

    public void Reset_Board()         // 체스판 초기화 함수
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
        toast.ShowToast("체스판 초기화");
    }
}


