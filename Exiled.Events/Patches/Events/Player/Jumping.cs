// -----------------------------------------------------------------------
// <copyright file="Jumping.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Player
{
#pragma warning disable SA1118
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using Exiled.Events.EventArgs;
    using Exiled.Events.Handlers;

    using HarmonyLib;

    using Mirror;

    using NorthwoodLib.Pools;

    using UnityEngine;

    using static HarmonyLib.AccessTools;

    /// <summary>
    /// Patches <see cref="PlayerMovementSync.ReceivePosition2DJump"/>.
    /// Adds the <see cref="Player.Jumping"/> event.
    /// </summary>
    [HarmonyPatch(typeof(PlayerMovementSync), nameof(PlayerMovementSync.ReceivePosition2DJump))]
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name
    internal static class Jumping2D
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            LocalBuilder ev = generator.DeclareLocal(typeof(JumpingEventArgs));
            LocalBuilder pos = generator.DeclareLocal(typeof(Vector2));

            Label retLabel = generator.DefineLabel();

            int index = newInstructions.FindIndex(instruction => instruction.opcode == OpCodes.Ldarg_0);

            newInstructions.InsertRange(index, new[]
            {
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(PositionMessage2DJump), nameof(PositionMessage2DJump.Position))),
                new CodeInstruction(OpCodes.Stloc_S, pos.LocalIndex),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(NetworkConnection), nameof(NetworkConnection.identity))),
                new CodeInstruction(OpCodes.Call, PropertyGetter(typeof(NetworkIdentity), nameof(NetworkIdentity.netId))),
                new CodeInstruction(OpCodes.Call, Method(typeof(API.Features.Player), nameof(API.Features.Player.Get), new[] { typeof(uint) })),
                new CodeInstruction(OpCodes.Ldloc_S, pos.LocalIndex),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Newobj, GetDeclaredConstructors(typeof(JumpingEventArgs))[0]),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Stloc_S, ev.LocalIndex),
                new CodeInstruction(OpCodes.Call, Method(typeof(Handlers.Player), nameof(Handlers.Player.OnJumping))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(JumpingEventArgs), nameof(JumpingEventArgs.IsAllowed))),
                new CodeInstruction(OpCodes.Brfalse_S, retLabel),
                new CodeInstruction(OpCodes.Ldloc_S, ev.LocalIndex),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(JumpingEventArgs), nameof(JumpingEventArgs.Player))),
                new CodeInstruction(OpCodes.Call, PropertyGetter(typeof(API.Features.Player), nameof(API.Features.Player.ReferenceHub))),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(ReferenceHub), nameof(ReferenceHub.playerMovementSync))),
                new CodeInstruction(OpCodes.Ldloc_S, pos.LocalIndex),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Call, Method(typeof(PlayerMovementSync), nameof(PlayerMovementSync.ReceivePosition2D), new[] { typeof(Vector2), typeof(bool) })),
            });

            newInstructions[newInstructions.Count - 1].WithLabels(retLabel);

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
#pragma warning restore SA1402 // File may only contain a single type
#pragma warning restore SA1649 // File name should match first type name

    /// <summary>
    /// Patches <see cref="PlayerMovementSync.ReceivePositionJump"/>.
    /// Adds the <see cref="Player.Jumping"/> event.
    /// </summary>
    [HarmonyPatch(typeof(PlayerMovementSync), nameof(PlayerMovementSync.ReceivePositionJump))]
    internal static class Jumping
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            LocalBuilder ev = generator.DeclareLocal(typeof(JumpingEventArgs));
            LocalBuilder pos = generator.DeclareLocal(typeof(Vector3));

            Label retLabel = generator.DefineLabel();

            int index = newInstructions.FindIndex(instruction => instruction.opcode == OpCodes.Ldarg_0);

            newInstructions.InsertRange(index, new[]
            {
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(PositionMessageJump), nameof(PositionMessageJump.Position))),
                new CodeInstruction(OpCodes.Stloc_S, pos.LocalIndex),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(NetworkConnection), nameof(NetworkConnection.identity))),
                new CodeInstruction(OpCodes.Call, PropertyGetter(typeof(NetworkIdentity), nameof(NetworkIdentity.netId))),
                new CodeInstruction(OpCodes.Call, Method(typeof(API.Features.Player), nameof(API.Features.Player.Get), new[] { typeof(uint) })),
                new CodeInstruction(OpCodes.Ldloc_S, pos.LocalIndex),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Newobj, GetDeclaredConstructors(typeof(JumpingEventArgs))[0]),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Stloc_S, ev.LocalIndex),
                new CodeInstruction(OpCodes.Call, Method(typeof(Handlers.Player), nameof(Handlers.Player.OnJumping))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(JumpingEventArgs), nameof(JumpingEventArgs.IsAllowed))),
                new CodeInstruction(OpCodes.Brfalse_S, retLabel),
                new CodeInstruction(OpCodes.Ldloc_S, ev.LocalIndex),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(JumpingEventArgs), nameof(JumpingEventArgs.Player))),
                new CodeInstruction(OpCodes.Call, PropertyGetter(typeof(API.Features.Player), nameof(API.Features.Player.ReferenceHub))),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(ReferenceHub), nameof(ReferenceHub.playerMovementSync))),
                new CodeInstruction(OpCodes.Ldloc_S, pos.LocalIndex),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Call, Method(typeof(PlayerMovementSync), nameof(PlayerMovementSync.ReceivePosition), new[] { typeof(Vector3), typeof(bool) })),
            });

            newInstructions[newInstructions.Count - 1].WithLabels(retLabel);

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}
