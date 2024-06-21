using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathSimulator : MonoBehaviour
{
    public Image questionImage;
    public Image bigQuestionImage;
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
                incorrectAnswerOutputText.text = "";
                StartCoroutine(Correct(correctAnswerOutputText));
                
            }
            else
            {
                correctAnswerOutputText.text = "";
                StartCoroutine(Incorrect(incorrectAnswerOutputText));
            }

            // Сброс текста InputField после нажатия кнопки Enter
            playerAnswerInputField.text = "";
        }
    }

    public void Qustion()
    {
        questionImage.sprite = Resources.Load<Sprite>(spriteName);
        bigQuestionImage.sprite = Resources.Load<Sprite>(spriteName);
        correctAnswerText.text = correctAnswer;
    }

    private IEnumerator Correct(Text textComponent)
    {
        textComponent.text = "Правильно!";
        yield return new WaitForSeconds(0.5f);
        textComponent.text = "";
        Destroy(enemy);
    }

    private IEnumerator Incorrect(Text textComponent)
    {
        textComponent.text = "Неправильно. Попробуй ещё раз!";
        yield return new WaitForSeconds(3f);
        textComponent.text = "";
    }
}