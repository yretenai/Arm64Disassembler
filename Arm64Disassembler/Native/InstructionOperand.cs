// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.InteropServices;
using Arm64Disassembler.Native.Arrays;

namespace Arm64Disassembler.Native;

// NOTE: Are these offsets stable between Linux and Windows? Not 100% sure.
// dotnet seems to give different offsets for .Sequential with Pack = 8.

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public record struct InstructionOperand {
	[field: FieldOffset(0)]
	public OperandClass OperandClass { get; set; }

	[field: FieldOffset(4)]
	public ArrangementSpec ArrangementSpec { get; set; }

	[field: FieldOffset(8)]
	public Array5<Register> Register { get; set; }

	[field: FieldOffset(0x1C)]
	public Condition Condition { get; set; }

	[field: FieldOffset(0x20)]
	public Array5<byte> ImplementationSpec { get; set; }

	[field: FieldOffset(0x28)]
	public SystemRegister SystemRegister { get; set; }

	[field: FieldOffset(0x2C)]
	public bool LaneUsed { get; set; }

	[field: FieldOffset(0x30)]
	public uint Lane { get; set; }

	[field: FieldOffset(0x38)]
	public ulong Immediate { get; set; }

	[field: FieldOffset(0x40)]
	public ShiftType ShiftType { get; set; }

	[field: FieldOffset(0x44)]
	public bool ShiftValueUsed { get; set; }

	[field: FieldOffset(0x48)]
	public uint ShiftValue { get; set; }

	[field: FieldOffset(0x4C)]
	public ShiftType ExtendType { get; set; }

	[field: FieldOffset(0x50)]
	public bool SignedImm { get; set; }

	[field: FieldOffset(0x51)]
	public byte PredicateQualifier { get; set; }

	[field: FieldOffset(0x52)]
	public bool MulVL { get; set; }

	[field: FieldOffset(0x54)]
	public ushort Tile { get; set; }

	[field: FieldOffset(0x58)]
	public SliceIndicator Slice { get; set; }

	[field: FieldOffset(0x5C)] public Str10 Name { get; set; }
}
