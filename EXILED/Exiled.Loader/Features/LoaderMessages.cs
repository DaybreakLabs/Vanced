// -----------------------------------------------------------------------
// <copyright file="LoaderMessages.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Loader.Features
{
    using System;

    /// <summary>
    /// A class that contains the different EXILED loader messages.
    /// </summary>
    public static class LoaderMessages
    {
        /// <summary>
        /// Gets the default loader message.
        /// </summary>
        public static string Default => @"

 /$$    /$$                                              /$$
| $$   | $$                                             | $$
| $$   | $$ /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$   /$$$$$$$
|  $$ / $$/|____  $$| $$__  $$ /$$_____/ /$$__  $$ /$$__  $$
 \  $$ $$/  /$$$$$$$| $$  \ $$| $$      | $$$$$$$$| $$  | $$
  \  $$$/  /$$__  $$| $$  | $$| $$      | $$_____/| $$  | $$
   \  $/  |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$|  $$$$$$$
    \_/    \_______/|__/  |__/ \_______/ \_______/ \_______/
                                                            ";

        /// <summary>
        /// Gets the loader message according to the actual month.
        /// </summary>
        /// <returns>The correspondent loader message.</returns>
        public static string GetMessage()
        {
            return Default;
        }
    }
}