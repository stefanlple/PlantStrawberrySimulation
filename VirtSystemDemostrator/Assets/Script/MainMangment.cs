using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMangment : MonoBehaviour
{
    [SerializeField] protected int currentStep = 1;
    int mistakesByUSer = 0;
    int helpGavetoUser = 0;
    [SerializeField] protected List<InterActionContainer> correctOrdercurr;
    [SerializeField] List<string> stepdiscrList;
    public static MainMangment mainMangment;
    [SerializeField] protected UIControll Ui;
    [SerializeField] bool clickAtive = true;
    [SerializeField] protected UnityEvent NextPostEvent;



    ////////////////////////////////////////////////////////////
    public event Action<int> OnNewStep;

    // Start is called before the first frame update
    void Awake()
    {
        
        mainMangment = this;
        Ui?.NewInstruction("Step "  + currentStep + ": " + correctOrdercurr[0].InteractionObject().SteptoMeDescription);
     
        Cursor.lockState = CursorLockMode.Locked; // Wieder�ndern bei Cam Modes
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            helpGavetoUser++;
            Ui.ChangeHelpCount(helpGavetoUser);
            Ui.ShowHelpText(correctOrdercurr[0].InteractionObject().CorrectionText);
        }
    }
    public virtual bool CheckClickedObjectInput(InteractionObject clicked)
    {
        if (clickAtive)
        {
            if (correctOrdercurr.Count == 0)
            {
                Debug.Log("Error no objects in List");
            }

            if (correctOrdercurr[0].InteractionObject() == clicked)
            {
                correctOrdercurr[0].StepSetup?.Invoke();

                NextPostEvent = correctOrdercurr[0].AfterSetpUpdate;
                correctOrdercurr.Remove(correctOrdercurr[0]);
                Ui.StopTempText();
                currentStep++;
                clickAtive = clicked.CheckBlockMode();
                if (clickAtive)
                {
                    print("Was here");
                    ChangingforNextStep();
                }
                return true;



            }
            else
            {
                mistakesByUSer++;
                Ui.ChangeMistakeCount(mistakesByUSer);
                Ui.ShowWrongAktionText(clicked.WrongSelectText);
                Debug.Log("Wrong Object");
                return false;
            }
        }
        return false;
    }
    public virtual void ChangingforNextStep()
    {

        NextPostEvent?.Invoke();
        clickAtive = true;
        if (currentStep == 2)
        {
            Cursor.lockState = CursorLockMode.None;
        }  
        if (correctOrdercurr.Count != 0)
        {
            print(correctOrdercurr[0].InteractionObject().SteptoMeDescription);
            Ui.NewInstruction("Step " + currentStep + ": " + correctOrdercurr[0].InteractionObject().SteptoMeDescription);
            Ui.ResetBlend();
        }
        else
        {
            Ui.NewInstruction("Finished");
            Ending();
        }
    }
    public void Ending()
    {
        clickAtive = false;
        Ui.ShowEndScreen(mistakesByUSer, helpGavetoUser);
    }


    
    /// //////////////////////////////////////////////////////////////////////
    public bool ClickAtive { get => clickAtive; set => clickAtive = value; }

}
