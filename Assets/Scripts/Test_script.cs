using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test_script : MonoBehaviour
{
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    public GameObject headPanel;
    public Button[] answerBttns = new Button[3];
    public Text interp;


    List<object> qList;
    QuestionList crntQ;
    int randQ;
    int a, b, c;


    public void BackTest()
    {
        interp.GetComponent<Animation>().Play("Interp");
        answerBttns[0].GetComponent<Button>().enabled = false;
        answerBttns[0].GetComponent<Image>().enabled = false;
        answersText[0].GetComponent<Text>().enabled = false;
        answerBttns[1].GetComponent<Button>().enabled = false;
        answerBttns[1].GetComponent<Image>().enabled = false;
        answersText[1].GetComponent<Text>().enabled = false;
        answerBttns[2].GetComponent<Button>().enabled = false;
        answerBttns[2].GetComponent<Image>().enabled = false;
        answersText[2].GetComponent<Text>().enabled = false;
        if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        else headPanel.GetComponent<Animator>().SetTrigger("Out");
    }
    public void OnClickPlay()
    {
        a = 0;
        b = 0;
        c = 0;
        qList = new List<object>(questions);
        questionGenerate();
        if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        else headPanel.GetComponent<Animator>().SetTrigger("In");
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
            qText.GetComponent<Animation>().Play("Textappear");
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
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
            qText.GetComponent<Animation>().Play("Text");
            interp.GetComponent<Animation>().Play("Interpappear");
            if (c > 4) interp.text = "Ты поддаешься эмоциям. Твое эмоциональное состояние нельзя назвать стабильным и гармоничным. Если в школе или среди друзей тебе еще удается контролировать вспышки агрессии, вспыльчивость и нервозность, то в личной жизни и с близкими людьми ты можешь позволить себе многое и даже перейти собственные границы. В такие моменты тебя можно сравнить с мыльным пузырем, наполненным эмоциями, который может лопнуть в любой момент, забрызгав содержимым всех, кто рядом. Возможно, это не так уж и плохо: люди хотя бы знают, чего от тебя ожидать, и уже не удивляются перепадам твоего настроения.";
            else
            {
                if (b > 4) interp.text = "Ты скрываешь свои эмоции. Ты не в ладу со своими эмоциями и чувствами. Даже когда внутри тебя бушует ураган, ты считаешь правильным оставлять все при себе: незачем другим знать о том, что ты переживаешь и с чем пытаешься справиться прямо сейчас. Для многих это может быть лишней информацией, и тебе не хочется никого обременять. Если у тебя в жизни случаются трудности, ты стараешься оградить близких от своих проблем и разобраться со всем самостоятельно. Тебе не хочется перекладывать ответственность за свою жизнь на кого-то ещё и признавать себя нуждающимся в помощи. К сожалению, избранная тактика едва ли идёт тебе на пользу. Она лишь заставляет тебя ещё больше мучиться и переживать, оставляя тебя с проблемой один на один и без чьей-либо поддержки. Позволь себе иногда давать слабину и просить о помощи.";
                else interp.text = "Ты в гармонии со своими эмоциями. Ты никогда не сдерживаешь себя в проявлении своих чувств. Наоборот, ты легко и открыто говоришь обо всем, что думаешь, делишься тем, что ощущаешь, обсуждаешь то, что тебя заботит и волнует. Ты привык(ла) обсуждать все свои внутренние переживания – так тебе легче с ними справляться. Ты не боишься показаться излишне экспрессивным человеком, если испытываешь счастье и радость, или слишком унылым(ой), когда тебя одолевает грусть. При этом ты отдаешь себе отчет в том, что живешь в социуме, где принято контролировать свои эмоции, и к выбору собеседника подходишь избирательно. Вываливать все, что у тебя на душе, первому встречному – не в твоих привычках: ты соблюдаешь границы и всегда чувствуешь, с кем и когда уместно поделиться переживаниями. Ты быстро выстраиваешь с людьми здоровые отношения и все время совершенствуешь свои навыки коммуникации.";
            }
            print(a);
            print(b);
            print(c);
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
        if (answersText[index].text.ToString() == crntQ.answers[0]) a++;
        if (answersText[index].text.ToString() == crntQ.answers[1]) b++;
        if (answersText[index].text.ToString() == crntQ.answers[2]) c++;
        qList.RemoveAt(randQ);
        questionGenerate();
        //questionGenerate();
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
}
