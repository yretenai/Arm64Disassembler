// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

namespace Arm64Disassembler.Native;

public enum SliceIndicator : uint {
	None = 0xffffffff,
	Horizontal = 0x0,
	Vertical = 0x1,
}
