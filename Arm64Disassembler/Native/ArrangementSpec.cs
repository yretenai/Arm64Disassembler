// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

namespace Arm64Disassembler.Native;

public enum ArrangementSpec : uint {
	None = 0x0,
	Full = 0x1,
	TwoDoubles = 0x2,
	FourSingles = 0x3,
	EightHalves = 0x4,
	SixteenBytes = 0x5,
	OneDouble = 0x6,
	TwoSingles = 0x7,
	FourHalves = 0x8,
	EightBytes = 0x9,
	OneSingle = 0xa,
	TwoHalves = 0xb,
	FourBytes = 0xc,
	OneHalf = 0xd,
	OneByte = 0xe,
}
