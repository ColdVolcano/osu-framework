// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Input.StateChanges.Events;
using osu.Framework.Input.States;

namespace osu.Framework.Input.StateChanges
{
    public class MidiControlInput : IInput
    {
        public readonly IEnumerable<(MidiControl, byte)> Controls;

        public MidiControlInput(MidiControl control, byte velocity)
        {
            Controls = new List<(MidiControl, byte)> { (control, velocity) };
        }

        public MidiControlInput(MidiState currentState, MidiState previousState)
        {
            Controls = currentState.Controls.Select(entry => (entry.Key, entry.Value)).ToList();
        }

        public void Apply(InputState state, IInputStateChangeHandler handler)
        {
            foreach (var (control, velocity) in Controls)
            {
                if (state.Midi.Controls.TryGetValue(control, out var current) && current == velocity)
                    continue;

                state.Midi.Controls[control] = velocity;
                handler.HandleInputStateChange(new MidiControlChangeEvent(state, this, control, velocity));
            }
        }
    }
}
