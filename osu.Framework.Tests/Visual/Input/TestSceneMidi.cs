// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace osu.Framework.Tests.Visual.Input
{
    public class TestSceneMidi : FrameworkTestScene
    {
        public TestSceneMidi()
        {
            var keyFlow = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
            };

            var controlFlow = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
            };

            for (MidiKey k = MidiKey.BNegative1; k < MidiKey.C8; k++)
                keyFlow.Add(new MidiKeyHandler(k));

            for (MidiControl c = MidiControl.BankSelect; c < MidiControl.PolyModeOn; c++)
                controlFlow.Add(new MidiControlHandler(c));

            Child = new BasicScrollContainer
            {
                RelativeSizeAxes = Axes.Both,
                Child = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Children = new[]
                    {
                        keyFlow,
                        controlFlow,
                    },
                },
            };
        }

        protected override bool OnMidiDown(MidiDownEvent e)
        {
            Console.WriteLine(e);
            return base.OnMidiDown(e);
        }

        protected override void OnMidiUp(MidiUpEvent e)
        {
            Console.WriteLine(e);
            base.OnMidiUp(e);
        }

        protected override bool OnMidiControlChange(MidiControlEvent e)
        {
            Console.WriteLine(e);
            return base.OnMidiControlChange(e);
        }

        protected override bool Handle(UIEvent e)
        {
            if (!(e is MouseEvent))
                Console.WriteLine("Event: " + e);
            return base.Handle(e);
        }

        private class MidiHandler : CompositeDrawable
        {
            private readonly Drawable background;

            public override bool HandleNonPositionalInput => true;

            protected MidiHandler(string text)
            {
                Height = 50;
                AutoSizeAxes = Axes.X;
                InternalChildren = new[]
                {
                    background = new Container
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.DarkGreen,
                        Alpha = 0,
                        Child = new Box { RelativeSizeAxes = Axes.Both },
                    },
                    new GridContainer
                    {
                        AutoSizeAxes = Axes.X,
                        RelativeSizeAxes = Axes.Y,
                        RowDimensions = new[]
                        {
                            new Dimension(),
                        },
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.AutoSize, minSize: 50),
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new Container
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    RelativeSizeAxes = Axes.Y,
                                    AutoSizeAxes = Axes.X,
                                    Padding = new MarginPadding { Horizontal = 10 },
                                    Child = new SpriteText
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = text,
                                    },
                                },
                            },
                        },
                    },
                };
            }

            protected void FadeIn(byte velocity)
            {
                const float base_opacity = 0.25f; // to make a velocity of 1 not completely invisible

                background.FadeTo(base_opacity + velocity / 128f * (1 - base_opacity), 100, Easing.OutQuint);
            }

            protected void FadeOut()
            {
                background.FadeOut(100);
            }
        }

        private class MidiKeyHandler : MidiHandler
        {
            private readonly MidiKey key;

            public MidiKeyHandler(MidiKey key)
                : base(key.ToString().Replace("Sharp", "#").Replace("Negative", "-"))
            {
                this.key = key;
            }

            protected override bool OnMidiDown(MidiDownEvent e)
            {
                if (e.Key != key)
                    return base.OnMidiDown(e);

                FadeIn(e.Velocity);

                return true;
            }

            protected override void OnMidiUp(MidiUpEvent e)
            {
                if (e.Key != key)
                    base.OnMidiUp(e);
                else
                    FadeOut();
            }
        }

        private class MidiControlHandler : MidiHandler
        {
            private readonly MidiControl control;

            public MidiControlHandler(MidiControl control)
                : base(Enum.IsDefined(typeof(MidiControl), control) ? control.ToString() : $"Control{(int)control}")
            {
                this.control = control;
            }

            protected override bool OnMidiControlChange(MidiControlEvent e)
            {
                if (e.Control != control)
                    return base.OnMidiControlChange(e);

                if (e.Value > 0)
                    FadeIn(e.Value);
                else
                    FadeOut();

                return true;
            }
        }
    }
}
