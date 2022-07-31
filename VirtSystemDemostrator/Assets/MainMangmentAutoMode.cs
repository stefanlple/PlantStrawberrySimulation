using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMangmentAutoMode : MainMangment
{


    // Start is called before the first frame update
    void Start()
    {
        MainMangment.mainMangment = this;
        StartCoroutine(WaitAtStart());
        Time.timeScale = 1;


    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            GoNext();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            GoBack();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }
    
    IEnumerator WaitAtStart()  // / weil sonstv alle Start zu awake ge�ndert werden m�ssetn 
    {
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
      
        SetUpSteps();
    }

    public override void ChangingforNextStep() // Bennenn wegen Polyminus 
    {
        // Im Falle von Auto Mode noch mal nicht n�chster Schritt
        print("And Again");
        Reapet();

    }
    public void Reapet()
    {
        correctOrdercurr[currentStep-1].InteractionObject().Clicked();
        correctOrdercurr[currentStep - 1].StepSetup.Invoke();
    }
    public void GoNext()
    {

        correctOrdercurr[currentStep - 1].AfterSetpUpdate.Invoke();

        if (correctOrdercurr[currentStep - 1].InteractionObject().gameObject.GetComponent<Animator>() != null)
        {
            correctOrdercurr[currentStep - 1].InteractionObject().gameObject.GetComponent<Animator>().SetTrigger("Break");
        }
       
        if (currentStep < correctOrdercurr.Count)
        {
            currentStep++;
            correctOrdercurr[currentStep - 1].StepSetupBeforeClick.Invoke();
            SetUpSteps();

        }
        else
        {
            print("X");
        }

    }

    private void SetUpSteps()
    {
        Ui.NewInstruction("Step " + currentStep + ": " + correctOrdercurr[currentStep-1].InteractionObject().SteptoMeDescription);

        print(currentStep-1);
        correctOrdercurr[currentStep-1].InteractionObject().Clicked();
        correctOrdercurr[currentStep - 1].StepSetup.Invoke();
    }

    public void GoBack()
    {
        if (correctOrdercurr[currentStep - 1].InteractionObject().gameObject.GetComponent<Animator>() != null)
        {
            correctOrdercurr[currentStep - 1].InteractionObject().gameObject.GetComponent<Animator>().SetTrigger("Break");
        }

        if (currentStep -1 != 0)
        {
            currentStep--;
            correctOrdercurr[currentStep - 1].StepSetupBeforeClick.Invoke();
            SetUpSteps();
        }

    }
    public override bool CheckClickedObjectInput(InteractionObject clicked)
    {
        return true;
    }
    public void SetTime()
    {
        Time.timeScale = Ui.ScrollBarValue()*10;
    }

}
