using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public TextAsset quizFile;
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;

    private Scoremanager scoremanager;

    private QuizData quizData;
    private int currentQuestionIndex = 0;

    private bool isAnswering = false;

    [System.Serializable]
    public class QuestionData
    {
        public string Question;
        public Answers[] Answers;
    }

    [System.Serializable]
    public class Answers
    {
        public string Answer;
        public bool IsCorrect;
    }

    [System.Serializable]
    public class QuizData
    {
        public QuestionData[] Questions;
    }

    void Start()
    {
        quizData = JsonUtility.FromJson<QuizData>(quizFile.text);
        ShowQuestion();
        scoremanager = FindObjectOfType<Scoremanager>();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < quizData.Questions.Length)
        {
            questionText.text = quizData.Questions[currentQuestionIndex].Question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = quizData.Questions[currentQuestionIndex].Answers[i].Answer;
            }
        }
        else
        {
            Debug.Log("Quiz finished!");
            SceneManager.LoadScene("Score");
        }
    }

    public void OnAnswerButtonClicked(int answerIndex)
    {
        if (!isAnswering)
        {
            isAnswering = true;
            StartCoroutine(ProcessAnswer(answerIndex));
        }
    }

    IEnumerator ProcessAnswer(int answerIndex)
    {
        if (quizData.Questions[currentQuestionIndex].Answers[answerIndex].IsCorrect)
        {
            Debug.Log("Correct!");
            scoremanager.score++;
            yield return StartCoroutine(LightUpButton(answerIndex, Color.green));
        }
        else
        {
            Debug.Log("Incorrect!");
            yield return StartCoroutine(LightUpButton(answerIndex, Color.red));
            int correctAnswerIndex = GetCorrectAnswerIndex();
            yield return StartCoroutine(LightUpButton(correctAnswerIndex, Color.green));
        }


        currentQuestionIndex++;
        ShowQuestion();
        isAnswering = false;
    }

    IEnumerator LightUpButton(int buttonIndex, Color color)
    {
        answerButtons[buttonIndex].image.color = color;
        yield return new WaitForSeconds(2f);
        answerButtons[buttonIndex].image.color = Color.white;
    }

    int GetCorrectAnswerIndex()
    {
        for (int i = 0; i < quizData.Questions[currentQuestionIndex].Answers.Length; i++)
        {
            if (quizData.Questions[currentQuestionIndex].Answers[i].IsCorrect)
            {
                return i;
            }
        }
        return -1;
    }
}
