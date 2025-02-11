using UnityEngine;

public class UserInput
{
    public bool IsEscape => 
        Input.GetKeyDown(KeyCode.Escape);
}
