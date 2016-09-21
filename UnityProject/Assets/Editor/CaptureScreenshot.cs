using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class CaptureScreenshot : Editor
{
	[MenuItem("Tools/Screen Shot")]
	private static void GameViewScreenShot()
	{
		string aFileName = "XXXXXX";
		Application.CaptureScreenshot(aFileName + ".png");
		Debug.Log("Screen Shot *******************");
	}
}
