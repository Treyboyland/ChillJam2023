using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextList", menuName = "Game/Text List")]
public class TextListSO : ScriptableObject
{
    [TextArea]
    [SerializeField]
    List<string> text;

    public List<string> Text { get => text; }
}
