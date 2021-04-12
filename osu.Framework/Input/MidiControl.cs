// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace osu.Framework.Input
{
    public enum MidiControl
    {
        BankSelect = 0,
        Modulation = 1,
        Breath = 2,
        Foot = 4,
        PortamentoTime = 5,
        DteMsb = 6,
        Volume = 7,
        Balance = 8,
        Pan = 10,
        Expression = 11,
        EffectControl1 = 12,
        EffectControl2 = 13,
        General1 = 16,
        General2 = 17,
        General3 = 18,
        General4 = 19,
        BankSelectLsb = 32,
        ModulationLsb = 33,
        BreathLsb = 34,
        FootLsb = 36,
        PortamentoTimeLsb = 37,
        DteLsb = 38,
        VolumeLsb = 39,
        BalanceLsb = 40,
        PanLsb = 42,
        ExpressionLsb = 43,
        Effect1Lsb = 44,
        Effect2Lsb = 45,
        General1Lsb = 48,
        General2Lsb = 49,
        General3Lsb = 50,
        General4Lsb = 51,
        Hold = 64,
        PortamentoSwitch = 65,
        Sostenuto = 66,
        SoftPedal = 67,
        Legato = 68,
        Hold2 = 69,
        SoundController1 = 70,
        SoundController2 = 71,
        SoundController3 = 72,
        SoundController4 = 73,
        SoundController5 = 74,
        SoundController6 = 75,
        SoundController7 = 76,
        SoundController8 = 77,
        SoundController9 = 78,
        SoundController10 = 79,
        General5 = 80,
        General6 = 81,
        General7 = 82,
        General8 = 83,
        PortamentoControl = 84,
        Rsd = 91,
        Effect1 = 91,
        Tremolo = 92,
        Effect2 = 92,
        Csd = 93,
        Effect3 = 93,
        Celeste = 94,
        Effect4 = 94,
        Phaser = 95,
        Effect5 = 95,
        DteIncrement = 96,
        DteDecrement = 97,
        NrpnLsb = 98,
        NrpnMsb = 99,
        RpnLsb = 100,
        RpnMsb = 101,
        AllSoundOff = 120,
        ResetAllControllers = 121,
        LocalControl = 122,
        AllNotesOff = 123,
        OmniModeOff = 124,
        OmniModeOn = 125,
        PolyModeOnOff = 126,
        PolyModeOn = 127,
    }
}