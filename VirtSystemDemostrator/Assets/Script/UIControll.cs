using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Instruction;
    [SerializeField] TextMeshProUGUI WrongAktion;
    [SerializeField] TextMeshProUGUI HelpText;
    [SerializeField] TextMeshProUGUI MistakeText;
    [SerializeField] Image BlackBlend;


    [SerializeField] TextMeshProUGUI StatusText;
    [SerializeField] Image StatusImage;

    [SerializeField] GameObject MainUI;
    [SerializeField] GameObject EndingUIA;
    [SerializeField] Image[] EImages;
    [SerializeField] TextMeshProUGUI[] EText;
    [SerializeField] TextMeshProUGUI mistakesMade;
    [SerializeField] TextMeshProUGUI hintstaken;

    [SerializeField] Scrollbar Time;

    private void Start()
    {
        EImages = EndingUIA.transform.GetComponentsInChildren<Image>(true);
        EText = EndingUIA.transform.GetComponentsInChildren<TextMeshProUGUI>(true);
       
    }

    public void NewInstruction(string text)
    {
        Instruction.text = text;
        if(Instruction.text.Length > 90){
            Instruction.fontSize=27;
        }else{
            Instruction.fontSize=40;
        }
    }
    public void ChangeHelpCount(int num)
    {
        HelpText.text = "Help:" + num;
    }
    public void ChangeMistakeCount(int num)
    {
        MistakeText.text = "Mistake:" + num;
    }
    public void StopTempText()
    {
        StopAllCoroutines();
        WrongAktion.color = new Color32(0, 0, 0, 0);
    }
    public void ShowWrongAktionText(string Text)
    {
        StopTempText();
        StartCoroutine(ShowAktionText_C(Text, new Color32(255, 0, 0, 255),2.5f));
    }
    public void ShowHelpText(string Text)
    {
        StopTempText();
        StartCoroutine(ShowAktionText_C(Text, new Color32(10, 10, 255, 255),5));
    }
    public void StartBlackBlending(bool blendin)
    {
        StartCoroutine(BlackBlending(blendin));
    }
    IEnumerator ShowAktionText_C(string Text,Color32 color,float time)
    {
        WrongAktion.text = Text;
        WrongAktion.color = new Color32(color.r, color.g, color.b, 255);
        WrongAktion.fontSize += 10;
        yield return new WaitForSeconds(0.1f);
        WrongAktion.fontSize -= 10;
        for (byte i= 255; i > 0; i--)
        {
            WrongAktion.color = new Color32(color.r, color.g, color.b, i);
            yield return new WaitForSeconds(time/255);
        }
    }
    IEnumerator BlackBlending(bool blendin)
    {
        if (blendin)
        {
            for (byte i = 1; i < 255; i++)
            {
                BlackBlend.color = new Color32(0, 0, 0, i);
                yield return new WaitForSeconds(0.005f);
            }
        }
        else
        {
            for (byte i = 255; i > 0; i--)
            {
                BlackBlend.color = new Color32(0, 0, 0, i);
                yield return new WaitForSeconds(0.005f);
            }
        }
       
    }
    public void StatusMessage(string text)
    {
        StatusImage.color = new Color32(255, 255, 255, 255);
        StatusText.text = text;
    }
    public void StatusMessageReset()
    {
        StatusImage.color = new Color32(0, 0, 0, 0);
        StatusText.text = "";
    }
    public void ShowEndScreen(int miss,int hint)
    {
        EndingUIA.SetActive(true);
        SetAlphaEndText(0);
        MainUI.GetComponent<Animator>().SetTrigger("Ending");
        StartCoroutine(EndingUI());
        mistakesMade.text = "You made " + miss  +" mistake(s)";
        hintstaken.text = "You needed " + hint +" hint(s)";

    }

    private void SetAlphaEndText(byte a)
    {
        foreach (Image image in EImages)
        {
            Color32 color = image.color;
            image.color = new Color32(color.r, color.g, color.b, a);
        }
        foreach (TextMeshProUGUI text in EText)
        {
            Color32 color = text.color;
            text.color = new Color32(color.r, color.g, color.b, a);
        }
    }

    IEnumerator EndingUI()
    {
        yield return new WaitForSeconds(0.5f);
        
        for (byte i = 1; i < 255; i++)
        {
            SetAlphaEndText(i);
            yield return new WaitForSeconds(0.01f);
        }
       
    }
    public float ScrollBarValue()
    {
        return Time.value;
    }
    public void ResetBlend()
    {
        StopAllCoroutines();
        BlackBlend.color = new Color32(0, 0, 0, 0);
    }


}
