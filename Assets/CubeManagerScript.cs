using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeManagerScript : MonoBehaviour
{
    public List<Color> colors = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Color GetRandomColor()
    {
        
        if (colors.Count > 0)
        {
            int rand = Random.Range(0, colors.Count);
            Color tempc = colors[rand];
            colors.RemoveAt(rand);
            return tempc;
        }
        else
        {
            return Color.white;
        }
    }
}
