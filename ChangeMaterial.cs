using UnityEngine;


public class ChangeMaterial : MonoBehaviour
{
    public Material otherMaterial = null;

    private bool usingOther = false;
    private MeshRenderer meshRenderer = null;
    private Material originalMaterial = null;

    // Awake löst bei jedem erstellen eines Gameobjektes aus
    private void Awake()
    {
        // Material componet holen
        meshRenderer = GetComponent<MeshRenderer>();
        //Orginal Material Speichern
        originalMaterial = meshRenderer.material;
    }

    // Das Andere Material anwenden
    public void SetOtherMaterial()
    {
        usingOther = true;
        meshRenderer.material = otherMaterial;
    }

    // Das start Material anwenden
    public void SetOriginalMaterial()
    {
        usingOther = false;
        meshRenderer.material = originalMaterial;
    }

    // Wechel zwischen beiden Materialen
    // Wenn Material 1 aktive ist dann wird auf Material 2 gewechselt und umgekehrt
    public void ToggleMaterial()
    {
        usingOther = !usingOther;

        if(usingOther)
        {
            meshRenderer.material = otherMaterial;
        }
        else
        {
            meshRenderer.material = originalMaterial;
        }
    }
}
