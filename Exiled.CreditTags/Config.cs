// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.CreditTags
{
    using System.ComponentModel;

    using Exiled.API.Interfaces;
    using Exiled.CreditTags.Enums;

    /// <inheritdoc />
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Info side - Badge, CustomPlayerInfo, Both")]
        public InfoSide Mode { get; set; } = InfoSide.Both;

        [Description("Overrides badge if exists")]
        public bool BadgeOverride { get; set; } = false;

        [Description("Overrides Custom Player Info if exists")]
        public bool CustomPlayerInfoOverride { get; set; } = false;

        [Description("Whether or not the plugin should ignore a player's DNT flag. By default (false), players with DNT flag will not be checked for credit tags.")]
        public bool IgnoreDntFlag { get; set; } = true;

        public bool UseBadge() => Mode == InfoSide.Both || Mode == InfoSide.Badge;

        public bool UseCustomPlayerInfo() => Mode == InfoSide.Both || Mode == InfoSide.CustomPlayerInfo;
    }
}
