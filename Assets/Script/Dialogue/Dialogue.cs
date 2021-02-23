using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    
    [TextArea(3,6)] // Limite de lineas que tiene el cada sentence en el sentenceList
    public string[] sentenceList; 
}
