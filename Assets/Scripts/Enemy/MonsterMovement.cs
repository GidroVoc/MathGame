using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterMovement : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float moveTime = 5f;
    public TMP_Text timerText;
    private RectTransform dynamicTextRectTransform;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        dynamicTextRectTransform = timerText.GetComponent<RectTransform>();
    }

    private void Update()
    {
        // ���� ����� ��������� �����, ��� 30 ������, ��������� � ����
        if (Vector3.Distance(transform.position, player.position) <= 30f)
        {
            StartCoroutine(MoveToPlayer());
        }

        UpdateTextPosition();
    }

    IEnumerator MoveToPlayer()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = player.position;

        float t = 0f;
        while (t < moveTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t / moveTime);

            // ���������� ������ �������
            float remainingTime = moveTime - t;
            int seconds = Mathf.RoundToInt(remainingTime);
            timerText.text = seconds.ToString();
            //Debug.Log("����� ��������: " + timerText.text);

            yield return null;
        }

        transform.position = targetPosition;
    }

    void UpdateTextPosition()
    {
        if (mainCamera != null)
        {
            // �������� ������� �������� ������� � �������� �����������
            Vector3 gameObjScreenPos = mainCamera.WorldToScreenPoint(transform.position);

            // ����������� �������� ���������� � ��������� ���������� Canvas
            Vector2 localPoint;
            RectTransform canvasRectTransform = timerText.canvas.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, gameObjScreenPos, mainCamera, out localPoint);

            float offsetY = 100.0f; // ������ ��������
            float offsetX = 100.0f; // ������ ��������

            // ������������� ������� ������ ������������ Canvas
            dynamicTextRectTransform.anchoredPosition = new Vector2(localPoint.x + offsetX, localPoint.y + timerText.preferredHeight + offsetY);
        }
    }
}
