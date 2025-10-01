using UnityEngine;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class TestDLL : MonoBehaviour
{
    [DllImport("LabSeven", EntryPoint = "TestSort")]
    public static extern void TestSort(int[] a, int length);

    public int[] a;

    public TextAsset intFile;

    void Start()
    {
        if(intFile != null)
        {
            string fileContent = intFile.text;

            string[] lines = fileContent.Split(',');

            a = lines.Select(s => int.Parse(s.Trim())).ToArray();
        }

        TestSort(a, a.Length);
        MeasureFunctionExecutionTime();
    }

    void MeasureFunctionExecutionTime()
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start(); // Start timing
        MyFunctionToTest(); // Call the function you want to measure
        stopwatch.Stop();  // Stop timing

        // Get the elapsed time
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log($"MyFunctionToTest took {elapsedMilliseconds} ms to execute.");
    }

    void MyFunctionToTest()
    {
        TestSort(a, a.Length); //Make sure you have the code that imports your native DLL and populates the array somewhere
    }
}
