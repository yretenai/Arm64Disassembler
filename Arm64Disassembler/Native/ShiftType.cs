// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;

namespace Arm64Disassembler.Native;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
public enum ShiftType : uint {
	None = 0x0,
	LSL = 0x1,
	LSR = 0x2,
	ASR = 0x3,
	ROR = 0x4,
	UXTW = 0x5,
	SXTW = 0x6,
	SXTX = 0x7,
	UXTX = 0x8,
	SXTB = 0x9,
	SXTH = 0xa,
	UXTH = 0xb,
	UXTB = 0xc,
	MSL = 0xd,
	End = 0xe,
}
