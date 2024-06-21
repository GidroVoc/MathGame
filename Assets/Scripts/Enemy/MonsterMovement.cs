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
        // Если игрок находится ближе, чем 30 единиц, двигаемся к нему
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

            // Обновление текста таймера
            float remainingTime = moveTime - t;
            int seconds = Mathf.RoundToInt(remainingTime);
            timerText.text = seconds.ToString();
            //Debug.Log("Текст обновлен: " + timerText.text);

            yield return null;
        }

        transform.position = targetPosition;
    }

    void UpdateTextPosition()
    {
        if (mainCamera != null)
        {
            // Получаем позицию игрового объекта в экранных координатах
            Vector3 gameObjScreenPos = mainCamera.WorldToScreenPoint(transform.position);

            // Преобразуем экранные координаты в локальные координаты Canvas
            Vector2 localPoint;
            RectTransform canvasRectTransform = timerText.canvas.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, gameObjScreenPos, mainCamera, out localPoint);

            float offsetY = 100.0f; // Пример смещения
            float offsetX = 100.0f; // Пример смещения

            // Устанавливаем позицию текста относительно Canvas
            dynamicTextRectTransform.anchoredPosition = new Vector2(localPoint.x + offsetX, localPoint.y + timerText.preferredHeight + offsetY);
        }
    }
}
