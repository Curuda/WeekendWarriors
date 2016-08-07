using UnityEngine;
using System.Collections;

public enum TileType { Selected, Hovered, Default }

public class TileScript : MonoBehaviour
{

    public Color defaultColour;
    public Color hoverColour;
    public Color selectedColour;

    public TileType tileType;

    [Range(0.0f, 10.0f)]
    public float hello;

    Material material;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (tileType == TileType.Selected)
        {
            material.SetColor("_Color", selectedColour);
        }
        else if (tileType == TileType.Hovered)
        {
            material.SetColor("_Color", hoverColour);
        }
        else if (tileType == TileType.Default)
        {
            material.SetColor("_Color", defaultColour);
        }

    }
}
