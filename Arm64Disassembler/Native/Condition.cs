// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

namespace Arm64Disassembler.Native;

public enum Condition : uint {
	Equal = 0x0,
	NotEqual = 0x1,
	CarrySet = 0x2,
	CarryClear = 0x3,
	Minus = 0x4,
	Plus = 0x5,
	OverflowSet = 0x6,
	OverflowClear = 0x7,
	UnsignedHigher = 0x8,
	UnsignedLower = 0x9,
	GreaterOrEqual = 0xa,
	LessOrEqual = 0xb,
	Greater = 0xc,
	Less = 0xd,
	Always = 0xe,
	Never = 0xf,
	End = 0x10,
}
