// -----------------------------------------------------------------------
// <copyright file="LoaderPlugin.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Loader
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using MEC;

    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;

    using Log = API.Features.Log;
    using Paths = API.Features.Paths;

    /// <summary>
    /// The Northwood PluginAPI Plugin class for the EXILED Loader.
    /// </summary>
    public class LoaderPlugin
    {
#pragma warning disable SA1401
        /// <summary>
        /// The config for the EXILED Loader.
        /// </summary>
        [PluginConfig]
        public static Config Config;
#pragma warning restore SA1401

        /// <summary>
        /// Called by PluginAPI when the plugin is enabled.
        /// </summary>
        [PluginEntryPoint("Vanced Loader", null, "Loads the Vanced Plugin Framework.", "ExMod-Team & DaybreakLabs")]
        [PluginPriority(byte.MinValue)]
        public void Enable()
        {
            if (Config == null)
            {
                Log.Error("Detected null config, EXILED will not be loaded.");
                return;
            }

            if (!Config.IsEnabled)
            {
                Log.Info("Vanced is disabled on this server via config.");
                return;
            }

            Log.Info($"Loading Vanced Version: {Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");
            Config.ExiledDirectoryPath = Path.Combine(Config.ExiledDirectoryPath, Server.Port.ToString());
            Paths.Reload(Config.ExiledDirectoryPath);

            Log.Info($"Vanced root path set to: {Paths.Exiled}");

            Directory.CreateDirectory(Paths.Exiled);
            Directory.CreateDirectory(Paths.Configs);
            Directory.CreateDirectory(Paths.Plugins);
            Directory.CreateDirectory(Paths.Dependencies);

            Timing.RunCoroutine(new Loader().Run());
        }
    }
}