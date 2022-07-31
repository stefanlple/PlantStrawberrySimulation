using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForDays : MonoBehaviour,IObjectAktion
{
    [SerializeField] Animator CamsControl;
    [SerializeField] UIControll Ui;

    [SerializeField] Light Sun;
    [SerializeField] int daytoWait = 14;
    [SerializeField] bool ShowInfoText = false;
    [SerializeField] string InfoText;
    [SerializeField] string otherWaitingtext = "Waiting till May";
    bool fastSkip = false;

    public int DaytoWait { get => daytoWait; set => daytoWait = value; }
    public bool ShowInfoText1 { get => ShowInfoText; set => ShowInfoText = value; }
    public string OtherWaitingtext { get => otherWaitingtext; set => otherWaitingtext = value; }
    public bool FastSkip { get => fastSkip; set => fastSkip = value; }

    private void Start()
    {
        GetComponent<InteractionObject>().SetObjectAktion(this);
    }
    public void DoyourThing()
    {
        StartCoroutine(GetInPosToWait());
    }

    public void DoneWithmyThing()
    {
        MainMangment.mainMangment.ChangingforNextStep();
    }
    
    IEnumerator WaitingForADay(int days)
    {

        int waitacc =40;
        print("WaitingTime");
        for (int i = 1; i <= days; i++)
        {
            if (!FastSkip) // weil bei kleinen werten Waitfor Secound ungenau wird(gerundet)
            {
                for (int a = 180; a > 1; a--)
                {

                    Sun.transform.Rotate(2, 0, 0);
                    yield return new WaitForSeconds(1 / (360 * waitacc));

                }
                waitacc++;
            }
            else
            {
                for (int a = 360 /waitacc; a > 1; a--)
                {

                    Sun.transform.Rotate(1 * waitacc, 0, 0);
                    yield return new WaitForSeconds(1 / (360 * waitacc));

                }
                waitacc++;
            }
           


            if (ShowInfoText)
            {
                Ui.StatusMessage(OtherWaitingtext + "\n " + InfoText);
            }
            else
            {
                Ui.StatusMessage("Waited for " + i.ToString() + " day(s)");
            }
          
        }
        Sun.transform.rotation = Quaternion.Euler(50, 90, 90); // nur f�r den Fall das die Roatation nicht korrekt ist 
        yield return new WaitForSeconds(0.65f);

        Ui.StatusMessageReset();
        StartCoroutine(GetOutPosToWait());


    }
    IEnumerator GetInPosToWait()
    {
        CamsControl.SetInteger("CamIndex", 2);
        yield return new WaitForSeconds(2);
        Ui.StartBlackBlending(true);
        yield return new WaitForSeconds(1);
        CamsControl.SetInteger("CamIndex", 3);
        yield return new WaitForSeconds(1);
        Ui.StartBlackBlending(false);
        yield return new WaitForSeconds(1);
        StartCoroutine( WaitingForADay(daytoWait));
    }
    IEnumerator GetOutPosToWait()
    {
        print("WaitingTimeOver");
        Ui.StartBlackBlending(true);
        yield return new WaitForSeconds(2);
        CamsControl.SetInteger("CamIndex", 0);
        yield return new WaitForSeconds(1);
        Ui.StartBlackBlending(false);
        DoneWithmyThing();
    }
    public void BreakWaiting()
    {
        StopAllCoroutines();
        StopCoroutine(WaitingForADay(daytoWait));
        Ui.StatusMessageReset();
        print("WaitingTimeOver");
        CamsControl.SetInteger("CamIndex", 1);
        CamsControl.SetInteger("CamIndex", 0);
        Ui.ResetBlend();
        Sun.transform.eulerAngles = new Vector3(50, 90, 90);


    }
    IEnumerator BreakWaitingR()
    {
        yield return new WaitForSeconds(0.01f);
    }
    public void ResetIt()
    {
        StopAllCoroutines();
        Ui.ResetBlend();
    }
}
