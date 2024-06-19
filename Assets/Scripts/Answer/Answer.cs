using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathSimulator : MonoBehaviour
{
    public Image questionImage;
    public InputField playerAnswerInputField;
    public Text correctAnswerText;
    public Text correctAnswerOutputText;
    public Text incorrectAnswerOutputText;
    public GameObject enemy;
    [SerializeField] public string spriteName;

    [SerializeField] private string correctAnswer;
    private string playerAnswer;

    void Start()
    {
        // Загрузка первой картинки
        Qustion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerAnswer = playerAnswerInputField.text;
            if (playerAnswer == correctAnswer)
            {
                StartCoroutine(ShowTextThenHide1(correctAnswerOutputText));
                incorrectAnswerOutputText.text = "";
                Destroy(enemy);
            }
            else
            {
                correctAnswerOutputText.text = "";
                StartCoroutine(ShowTextThenHide2(incorrectAnswerOutputText));
            }

            // Сброс текста InputField после нажатия кнопки Enter
            playerAnswerInputField.text = "";
        }
    }

    public void Qustion()
    {
        questionImage.sprite = Resources.Load<Sprite>(spriteName);
        correctAnswerText.text = correctAnswer;
    }

    private IEnumerator ShowTextThenHide1(Text textComponent)
    {
        textComponent.text = "Правильно!";
        yield return new WaitForSeconds(3f);
        textComponent.text = "";

        // Переход к следующему вопросу
        //questionImage.sprite = Resources.Load<Sprite>("Question2");
        //correctAnswer = "22";
        //correctAnswerText.text = correctAnswer
    }

    private IEnumerator ShowTextThenHide2(Text textComponent)
    {
        textComponent.text = "Неправильно. Попробуй ещё раз!";
        yield return new WaitForSeconds(3f);
        textComponent.text = "";
    }
}