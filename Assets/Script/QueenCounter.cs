using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QueenCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // UI Text
    public Touch_Screen touchScreen;    // 퀸 개수 가져오기용

    void Update()
    {
        int count = touchScreen.count;

        counterText.text = $"퀸 개수 : {count}";

        if (count == 8)
            counterText.color = Color.Lerp(counterText.color, Color.red, 0.5f);
        else
            counterText.color = Color.Lerp(counterText.color, Color.white, 0.5f);
    }
}
