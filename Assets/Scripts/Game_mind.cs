using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_mind : MonoBehaviour
{
    public QuestList[] quests;
    public Text[] answersText;
    public Text qText;
    public GameObject head1Panel;
    public Button[] answerBttns = new Button[3];
    public Text interp;

    List<object> qList;
    QuestList crntQ;
    int randQ;
    int count = 0;

    public void BackTest()
    {
        interp.GetComponent<Text>().enabled = false;
        qText.GetComponent<Text>().enabled = false;
        answerBttns[0].GetComponent<Button>().enabled = false;
        answerBttns[0].GetComponent<Image>().enabled = false;
        answersText[0].GetComponent<Text>().enabled = false;
        answerBttns[1].GetComponent<Button>().enabled = false;
        answerBttns[1].GetComponent<Image>().enabled = false;
        answersText[1].GetComponent<Text>().enabled = false;
        answerBttns[2].GetComponent<Button>().enabled = false;
        answerBttns[2].GetComponent<Image>().enabled = false;
        answersText[2].GetComponent<Text>().enabled = false;
        if (!head1Panel.GetComponent<Animator>().enabled) head1Panel.GetComponent<Animator>().enabled = true;
        else head1Panel.GetComponent<Animator>().SetTrigger("Out1");
    }

    public void OnClickPlay()
    {
        qList = new List<object>(quests);
        qText.GetComponent<Text>().enabled = true;
        questionGenerate();
        if (!head1Panel.GetComponent<Animator>().enabled) head1Panel.GetComponent<Animator>().enabled = true;
        else head1Panel.GetComponent<Animator>().SetTrigger("In1");
        answerBttns[0].GetComponent<Button>().enabled = true;
        answerBttns[0].GetComponent<Image>().enabled = true;
        answersText[0].GetComponent<Text>().enabled = true;
        answerBttns[1].GetComponent<Button>().enabled = true;
        answerBttns[1].GetComponent<Image>().enabled = true;
        answersText[1].GetComponent<Text>().enabled = true;
        answerBttns[2].GetComponent<Button>().enabled = true;
        answerBttns[2].GetComponent<Image>().enabled = true;
        answersText[2].GetComponent<Text>().enabled = true;
    }

    void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
            StartCoroutine(animBttns());
        }
        else
        {
            answerBttns[0].GetComponent<Button>().enabled = false;
            answerBttns[0].GetComponent<Image>().enabled = false;
            answersText[0].GetComponent<Text>().enabled = false;
            answerBttns[1].GetComponent<Button>().enabled = false;
            answerBttns[1].GetComponent<Image>().enabled = false;
            answersText[1].GetComponent<Text>().enabled = false;
            answerBttns[2].GetComponent<Button>().enabled = false;
            answerBttns[2].GetComponent<Image>().enabled = false;
            answersText[2].GetComponent<Text>().enabled = false;
            qText.GetComponent<Text>().enabled = false;
            print(count);
            interp.GetComponent<Text>().enabled = true;
            if (count == 7) interp.text = "Вы дали 100% правильных ответов. Отличная работа!";
            if (count == 6) interp.text = "Вы дали 86% правильных ответов. Хорошая работа!";
            if (count == 5) interp.text = "Вы дали 71% правильных ответов. Очень даже неплохо!";
            if (count == 4) interp.text = "Вы дали 57% правильных ответов. Мы совершаем ошибки, чтобы учиться!";
            if (count == 3) interp.text = "Вы дали 43% правильных ответов. Нужно еще немного постараться.";
            if (count == 2) interp.text = "Вы дали 29% правильных ответов. Эмоции не такая уж простая вещь, у вас всё получится!";
            if (count == 1) interp.text = "Вы дали 14% правильных ответов. Нужно еще поработать над этой темой.";
            if (count == 0) interp.text = "Вы дали 0% правильных ответов. Попробуйте почитать полезную информацию про эмоции.";
        }
    }

    IEnumerator animBttns()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        int f = 0;
        while(f < answerBttns.Length)
        {
            if (!answerBttns[f].gameObject.activeSelf) answerBttns[f].gameObject.SetActive(true);
            f++;
        }
        for(int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
        yield break;
    }
    
    public void answersBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) count++;
        qList.RemoveAt(randQ);
        questionGenerate();
    }
}
[System.Serializable]
public class QuestList
{
    public string question;
    public string[] answers = new string[3];
}
