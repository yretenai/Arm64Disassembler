// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.InteropServices;
using Arm64Disassembler.Native;

namespace Arm64Disassembler;

public class InstructionCollection : List<Instruction> {
	public void Add(Span<byte> bytes, nuint address) {
		Add(MemoryMarshal.Cast<byte, uint>(bytes), address);
	}

	public void Add(Span<uint> words, nuint address) {
		foreach (var word in words) {
			Add(word, address);
			address += 4;
		}
	}

	public unsafe void Add(uint word, nuint address) {
		var instr = stackalloc Instruction[1];
		_ = NativeMethods.aarch64_decompose(word, instr, address);
		Add(instr[0]);
	}
}
