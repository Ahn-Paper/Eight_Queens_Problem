using UnityEngine;
using TMPro;
using System.Collections;

public class Toast : MonoBehaviour
{
    public TextMeshProUGUI toastText;
    public float fadeDuration = 0.5f; //페이드 인/아웃 시간

    private CanvasGroup canvasGroup;

    void Awake() //토스트 메세지 투명화
    {
        canvasGroup = GetComponent<CanvasGroup>();    
        canvasGroup.alpha = 0f;
    }

    public void ShowToast(string message) //토스트 호출 함수
    {
        StopAllCoroutines(); //메세지 중첩 호출 시 이전 메세지 중지
        StartCoroutine(ShowToastCoroutine(message));
    }

    private IEnumerator ShowToastCoroutine(string message) //페이드 인/아웃 함수
    {
        toastText.text = message;

        // 페이드 인
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // 텍스트 유지
        yield return new WaitForSeconds(0.8f);

        // 페이드 아웃
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }
}
