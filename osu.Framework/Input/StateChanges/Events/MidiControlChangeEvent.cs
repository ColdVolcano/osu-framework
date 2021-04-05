// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Input.States;

namespace osu.Framework.Input.StateChanges.Events
{
    public class MidiControlChangeEvent : InputStateChangeEvent
    {
        public readonly MidiControl Control;
        public readonly byte Value;

        public MidiControlChangeEvent(InputState state, IInput input, MidiControl control, byte value)
            : base(state, input)
        {
            Control = control;
            Value = value;
        }
    }
}
