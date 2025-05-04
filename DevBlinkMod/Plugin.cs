//﻿using BepInEx;
using DevBlinkMod.Scripts;
using System.IO;
using System.Reflection;
using UnityEngine;
using MelonLoader;

namespace DevBlinkMod
{
    public class Plugin : MelonMod
    {
        public static Plugin Instance { get; private set; }
        private bool loaded;
        public Texture2D faceSheet;

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (!loaded)
            {
                loaded = true;
                Instance = this;
                BlinkLogger.LogMessage("DevBlinkMod awoken", BlinkLogger.LogType.Default);
            
                Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"DevBlinkMod.Resources.blinksheet.png");
                byte[] bytes = new byte[manifestResourceStream.Length];
                manifestResourceStream.ReadAsync(bytes, 0, bytes.Length);

                faceSheet = new Texture2D(192, 65, TextureFormat.RGB24, false)
                {
                    wrapMode = TextureWrapMode.Repeat,
                    filterMode = FilterMode.Point,
                    name = "Blink Sheet"
                };
                faceSheet.LoadImage(bytes);
                faceSheet.Apply();
                BlinkLogger.LogMessage("Generated face texture", BlinkLogger.LogType.Default);
            }
        }
    }
}
