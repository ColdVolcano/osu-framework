// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Input.States;
using osu.Framework.Logging;

namespace osu.Framework.Input
{
    public class MidiControlEventManager
    {
        private readonly MidiControl control;

        [NotNull]
        protected IEnumerable<Drawable> InputQueue => GetInputQueue.Invoke() ?? Enumerable.Empty<Drawable>();

        /// <summary>
        /// A function to retrieve the input queue.
        /// </summary>
        internal Func<IEnumerable<Drawable>> GetInputQueue;

        public MidiControlEventManager(MidiControl control)
        {
            this.control = control;
        }

        public void HandleControlChange(InputState state, byte value)
        {
            PropagateEvent(InputQueue, new MidiControlEvent(state, control, value));
        }

        protected Drawable PropagateEvent(IEnumerable<Drawable> drawables, UIEvent e)
        {
            var handledBy = drawables.FirstOrDefault(target => target.TriggerEvent(e));

            if (handledBy != null)
                Logger.Log($"{e} handled by {handledBy}.", LoggingTarget.Runtime, LogLevel.Debug);

            return handledBy;
        }
    }
}
