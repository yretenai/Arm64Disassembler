// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;

namespace Arm64Disassembler.Native;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
public enum OperandClass : uint {
	NONE = 0x0,
	IMM32 = 0x1,
	IMM64 = 0x2,
	FIMM32 = 0x3,
	STR_IMM = 0x4,
	REG = 0x5,
	MULTI_REG = 0x6,
	SYS_REG = 0x7,
	MEM_REG = 0x8,
	MEM_PRE_IDX = 0x9,
	MEM_POST_IDX = 0xa,
	MEM_OFFSET = 0xb,
	MEM_EXTENDED = 0xc,
	SME_TILE = 0xd,
	INDEXED_ELEMENT = 0xe,
	ACCUM_ARRAY = 0xf,
	LABEL = 0x10,
	CONDITION = 0x11,
	NAME = 0x12,
	IMPL_SPECIFIC = 0x13,
}
