using UnityEngine;

public class Reset_Btn : MonoBehaviour
{

    public Touch_Screen touchScreen;

    public void OnReset()
    {
        touchScreen.Reset_Board();
    }
}
