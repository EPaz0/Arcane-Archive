using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color = Color.white;

    //helper list to cache all the materials of this object
    private List<Material> materials;

    //Gets all the materials from each renderer
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            //A single child-object might have multiple materials on it
            //so we need to add all of them to our list

            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val) 
        {
            
            foreach (var material in materials)
            {
                Debug.Log("Metrials: " + material);
                //We need to enable the EMISSION
                material.EnableKeyword("_EMISSION");
                //before we can set the color
                material.SetColor("_EmissionColor", color * 100);
                Debug.Log($"Emission Color: {material.GetColor("_EmissionColor")}");
            }
        }
        else
        {
            foreach (var material in materials)
            {
                //We can just disable the EMISSION
                //if we dont use emission in any other way
                material.DisableKeyword("_EMISSION");
            }
        }

    }

}
