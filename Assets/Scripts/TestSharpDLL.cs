using UnityEngine;
using Lab7;

public class TestSharpDLL : MonoBehaviour
{
    public TextAsset intFile;  // assign in Inspector

    void Start()
    {
        // Use the wrapper instead of direct DllImport
        Class1 timer = new Class1();
        timer.intFile = intFile;
        timer.Start();
    }
}
