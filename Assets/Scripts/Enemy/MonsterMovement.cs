using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMovement : MonoBehaviour
{
    public Transform player;
    public float moveTime = 5f;
    public Text timerText;

    private void Update()
    {
        // Если игрок находится ближе, чем 30 единиц, двигаемся к нему
        if (Vector3.Distance(transform.position, player.position) <= 30f)
        {
            StartCoroutine(MoveToPlayer());
        }
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
            // timerText.text = seconds.ToString();

            yield return null;
        }

        transform.position = targetPosition;
    }
}