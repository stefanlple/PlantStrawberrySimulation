using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseSelectionHighlight : MonoBehaviour
{
        [SerializeField] private Material highlightMaterial = null;

        private Material[] defaultMaterial;
        private MeshRenderer meshRenderer;


        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            defaultMaterial = meshRenderer.materials;
        }

        private void OnMouseEnter()
        {
            HighLight();
        }

        private void HighLight()
        {
            meshRenderer.material = highlightMaterial;
        }

        private void OnMouseExit()
        {
            meshRenderer.material = defaultMaterial[0];
        }
}
