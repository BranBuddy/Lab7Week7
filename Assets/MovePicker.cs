using UnityEngine;

public class MovePicker : MonoBehaviour
{
    [MovePicker(options = new string[] { "rock", "paper", "scissors" })]
    public string nextMove;
}

public class MovePickerAttribute : PropertyAttribute
{
    public string[] options;
}
