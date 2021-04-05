// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using JetBrains.Annotations;
using osu.Framework.Extensions.TypeExtensions;
using osu.Framework.Input.States;

namespace osu.Framework.Input.Events
{
    public class MidiControlEvent : UIEvent
    {
        public readonly MidiControl Control;
        public readonly byte Value;

        public MidiControlEvent([NotNull] InputState state, MidiControl control, byte value)
            : base(state)
        {
            Control = control;
            Value = value;
        }

        public override string ToString() => $"{GetType().ReadableName()}({Control})";
    }
}
