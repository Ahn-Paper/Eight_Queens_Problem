using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PopUp_Panel : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI PanelText;

    void Update()
    {
        if (Panel.activeSelf && Input.GetMouseButtonDown(0))
        {
            Panel.SetActive(false);
        }
    }

    public void Show_Message(string message) //�г� �޼��� ��� �Լ�
    {
        PanelText.text = message;
        Panel.SetActive(true);
    }
}
