using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTester : MonoBehaviour
{
    public TMP_Text displayQuestion;

    public DataManager data;

    public int n = 0;

    private void Awake()
    {
        displayQuestion.text = data.myQuestions[0].question;
    }

    void Start()
    {
        //GetComponent<InputField>().onSubmit.AddListener(OnSubmit);
    }

    public void NextQuestion()
    {
        n++;

        if (n > 9)
        {
            n = 0;
        }

        displayQuestion.text = data.myQuestions[n].question;
    }

    public void PreviousQuestion()
    {
        n--;

        if (n < 0)
        {
            n = 9;
        }

        displayQuestion.text = data.myQuestions[n].question;
    }

    void OnSubmit()
    {
        print("Hi!");
    }
}
