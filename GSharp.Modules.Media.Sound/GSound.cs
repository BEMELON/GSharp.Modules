﻿using System;
using SoundLIB;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Media.Sound
{
    public class GSound : GModule
    {
        static GSound()
        {
            EngineBASS.Registration();
            EngineBASS.Initialize(IntPtr.Zero);
        }

        [GCommand("{object}파일 재생")]
        public static void Play(string path)
        {
            EngineBASS.Path = path;
            EngineBASS.Play();
        }

        [GCommand("재생 정지")]
        public static void Stop()
        {
            EngineBASS.Stop();
        }

        [GCommand("템포를 {object}로 설정")]
        public static void SetTempo(int value)
        {
            EngineBASS.Tempo = value;
        }

        [GCommand("음정을 {object}로 설정")]
        public static void SetPitch(int value)
        {
            EngineBASS.Pitch = value;
        }

        [GCommand("음량을 {object}%로 설정")]
        public static void SetVolume(int value)
        {
            EngineBASS.Volume = value;
        }

        [GCommand("{object} VST 적용")]
        public static void SetVST(string path)
        {
            EngineBASS.VST_SetPlugin = path;
            EngineBASS.VST_OpenEditor();
        }

        [GCommand("{object} WADSP 적용")]
        public static void SetWADSP(string path)
        {
            EngineBASS.WADSP_LoadPlugin(path, 0, 0, 0);
        }
    }
}
