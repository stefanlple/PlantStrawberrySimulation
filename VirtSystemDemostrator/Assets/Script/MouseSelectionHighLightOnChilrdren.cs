using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectionHighLightOnChilrdren : MonoBehaviour
{
    [SerializeField] public Material highlightMaterial = null;

    private List<Material[]> defaultMaterialList = new List<Material[]>();
    private MeshRenderer[] meshRenderers;


    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer MS in meshRenderers)
        {
            defaultMaterialList.Add(MS.materials);
        }
    }

    private void OnMouseEnter()
    {
        if(highlightMaterial!=null){
        foreach (MeshRenderer MS in meshRenderers)
        {           
           MS.material = highlightMaterial;         
        }
        }else{
            OnMouseExit();
        }
    }

    private void OnMouseExit()
    {
        int i = 0;
        foreach (MeshRenderer MS in meshRenderers)
        {
            MS.materials = defaultMaterialList[i];
            i++;
        }
    }
}
