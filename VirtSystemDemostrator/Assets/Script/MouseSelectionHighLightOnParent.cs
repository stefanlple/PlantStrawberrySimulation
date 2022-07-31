using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectionHighLightOnParent : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial = null;

    private List<Material> defaultMaterialList = new List<Material>();
    private MeshRenderer[] meshRenderers;


    private void Start()
    {
        meshRenderers = GetComponentsInParent<MeshRenderer>();
        foreach (MeshRenderer MS in meshRenderers)
        {
            print(MS.material);
            defaultMaterialList.Add(MS.material);
        }
    }

    private void OnMouseEnter()
    {
        foreach (MeshRenderer MS in meshRenderers)
        {
            MS.material = highlightMaterial;
        }
    }

    private void OnMouseExit()
    {
        int i = 0;
        foreach (MeshRenderer MS in meshRenderers)
        {
            MS.material = defaultMaterialList[i];
            i++;
        }
    }
}
