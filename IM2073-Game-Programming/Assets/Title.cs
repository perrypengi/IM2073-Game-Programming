using UnityEngine;
using System.Runtime.InteropServices;

public class WindowTitleSetter : MonoBehaviour
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SetWindowText(System.IntPtr hwnd, System.String lpString);
    [DllImport("user32.dll")]
    static extern System.IntPtr GetActiveWindow();

    void Start()
    {
        System.IntPtr windowHandle = GetActiveWindow();
        SetWindowText(windowHandle, "Halloween Adventure");
    }
}