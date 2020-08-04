// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Updater
{
    using System;
    using System.ComponentModel;

    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether testing releases have to be downloaded or not.
        /// </summary>
        [Description("Indicates whether testing releases have to be downloaded or not")]
        public bool ShouldDownloadTestingReleases { get; internal set; } = false;

        /// <summary>
        /// Gets a value that indicates which assemblies should be excluded from the update.
        /// </summary>
        [Description("Indicates which assemblies should be excluded from the update")]
        public string[] ExcludeAssemblies { get; internal set; } = Array.Empty<string>();
    }
}
