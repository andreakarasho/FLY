﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClassicUO.Engine.Utility;
using SDL2;

namespace ClassicUO.Engine
{
    public static class EngineDispatcher
    {
        private static bool _configured;

        public static List<Window> AllWindows = new List<Window>();



        public static void Configure(Backends backend)
        {
            Debug.Assert(!_configured, "Engine has been already configured!");

            string osVersion = string.Empty;

            try
            {
                osVersion = SDL.SDL_GetPlatform();
            }
            catch (DllNotFoundException ex)
            {
                Logger.LogError("SDL2 was not found!");

                throw ex;
            }
            catch (BadImageFormatException ex)
            {
                string error = $"This process is {(IntPtr.Size == 4 ? "32" : "64")} bit.";
              
                Logger.LogError(error);

                throw new BadImageFormatException(error, ex);
            }


            SDL.SDL_SetMainReady();


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Platform.OS = OS.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Platform.OS = OS.Linux;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Platform.OS = OS.macOS;
            }
            else
            {
                Logger.LogError("Invalid OS!");

                throw new EngineException("Invalid OS!");
            }

            CheckBackendCompatibility(backend);
            ConfigureGlobalMouse(osVersion);
            FixVisualStudioDebugger(osVersion);
            FixWindowsPaintEvent();


            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO | 
                             SDL.SDL_INIT_JOYSTICK | 
                             SDL.SDL_INIT_GAMECONTROLLER | 
                             SDL.SDL_INIT_HAPTIC) != 0)
            {
                string error = "Unable to initialize SDL: " + SDL.SDL_GetError();
              
                Logger.LogError(error);

                throw new EngineException(error);
            }

            SDL.SDL_DisableScreenSaver();

            _configured = true;
        }

        public static void Start()
        {

        }

        public static void Quit()
        {
            SDL.SDL_Quit();
        }

        public static void PollEvent()
        {
            int count = AllWindows.Count;

            while (SDL.SDL_PollEvent(out SDL.SDL_Event e) != 0)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (AllWindows[i].IsRunning && SDL.SDL_GetWindowID(AllWindows[i].Handle) == e.window.windowID)
                    {
                        AllWindows[i].ProcessEvent(ref e);

                        break;
                    }
                }
            }
        }

        private static void CheckBackendCompatibility(Backends backend)
        {
            switch (Platform.OS)
            {
                case OS.Windows:

                    if (backend == Backends.Metal)
                    {
                        throw new EngineException("Metal is not a suitable backend on Windows");
                    }

                    break;
                case OS.Linux:

                    if (backend == Backends.Metal)
                    {
                        throw new EngineException("Metal is not a suitable backend on Linux");
                    }
                    else if (backend == Backends.D3D11)
                    {
                        throw new EngineException("D3D11 is not a suitable backend on Linux");
                    }

                    break;
                case OS.macOS:

                    if (backend == Backends.D3D11)
                    {
                        throw new EngineException("D3D11 is not a suitable backend on macOS");
                    }

                    break;

                default:

                    throw new EngineException("No suitable backend found.");
            }
        }

        private static void ConfigureGlobalMouse(string osVersion)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            string[] compatiblesOS =
            {
                "windows",
                "mac os x",
                "linux",
                "freebsd",
                "openbsd",
                "netbsd"
            };

            for (int i = 0; i < compatiblesOS.Length; ++i)
            {
                if (osVersion.Equals(compatiblesOS[i], comparison))
                {
                    Platform.SUPPORT_GLOBAL_MOUSE = true;

                    break;
                }
            }
        }

        private static void FixVisualStudioDebugger(string osVersion)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            if (osVersion.Equals("windows", comparison) ||
                osVersion.Equals("winrt", comparison))
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    SDL.SDL_SetHint(SDL.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING, "1");
                }
            }
        }

        private static void FixWindowsPaintEvent()
        {
            if (Platform.OS == OS.Windows)
            {
                // TODO:
            }
        }
    }
}
