using UnityEngine;
using TMPro;
using System.Collections;

public class Toast : MonoBehaviour
{
    public TextMeshProUGUI toastText;
    public float fadeDuration = 0.5f; //���̵� ��/�ƿ� �ð�

    private CanvasGroup canvasGroup;

    void Awake() //�佺Ʈ �޼��� ����ȭ
    {
        canvasGroup = GetComponent<CanvasGroup>();    
        canvasGroup.alpha = 0f;
    }

    public void ShowToast(string message) //�佺Ʈ ȣ�� �Լ�
    {
        StopAllCoroutines(); //�޼��� ��ø ȣ�� �� ���� �޼��� ����
        StartCoroutine(ShowToastCoroutine(message));
    }

    private IEnumerator ShowToastCoroutine(string message) //���̵� ��/�ƿ� �Լ�
    {
        toastText.text = message;

        // ���̵� ��
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // �ؽ�Ʈ ����
        yield return new WaitForSeconds(0.8f);

        // ���̵� �ƿ�
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
