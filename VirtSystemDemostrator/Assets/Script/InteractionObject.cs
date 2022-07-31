using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
   [SerializeField] string steptoMeDescription;
   [SerializeField] string correctionText;
   [SerializeField] string wrongSelectText;
   [SerializeField] bool noClickinterruption = true;
    IObjectAktion ObjectAktion; // [SerializeField] wird nicht funktioniren das IObjectAktion muss sich selbst setzten | In Start GetComponent<InteractionObject>().SetObjectAktion(this); machen oder umgekerhtes [SerialedField] 

   [SerializeField] bool DoITWithoutClick = false;

    public string SteptoMeDescription { get => steptoMeDescription; set => steptoMeDescription = value; }
    public string CorrectionText { get => correctionText; set => correctionText = value; }
    public string WrongSelectText { get => wrongSelectText; set => wrongSelectText = value; }
    public bool DoWithoutClick1 { get => DoITWithoutClick; set => DoITWithoutClick = value; }


    private void Start()
    {
        print(":____________________________" + ObjectAktion);

    }
    public bool CheckBlockMode()
    {
        return noClickinterruption;
    }


    private void OnMouseDown()
    {
       
        Clicked();
    }
    public void Clicked()
    {
        bool sucess = MainMangment.mainMangment.CheckClickedObjectInput(this);
        print(sucess +"" + ObjectAktion);
        if (sucess & ObjectAktion != null)
        {
            print("Aktion from " + gameObject.name);
            ObjectAktion.DoyourThing();
            
        }

    }
    public void ImDoneGoOn() // Lieber die Line hier bei ObjectAktion in DonemyThing callen
    {
        MainMangment.mainMangment.ChangingforNextStep();
    }
    public void SetObjectAktion(IObjectAktion ObjAkt)
    {
       
        ObjectAktion = ObjAkt;
        print(ObjectAktion + "has Appiled");
    }
}
