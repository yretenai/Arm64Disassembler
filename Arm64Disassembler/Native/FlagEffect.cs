// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

namespace Arm64Disassembler.Native;

public enum FlagEffect : uint {
	None = 0x0,
	SetsSomething = 0x1,
	SetsNormal = 0x2,
	SetsFloat = 0x3,
}
