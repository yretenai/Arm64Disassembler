// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.InteropServices;
using System.Text;
using Arm64Disassembler.Native.Arrays;

namespace Arm64Disassembler.Native;

// NOTE: Are these offsets stable between Linux and Windows? Not 100% sure.
// dotnet seems to give different offsets for .Sequential with Pack = 8.

[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public record struct Instruction {
	[field: FieldOffset(0)]
	public uint InstructionWord { get; set; }

	[field: FieldOffset(4)]
	public InstructionEncoding InstructionEncoding { get; set; }

	[field: FieldOffset(8)]
	public Operation Operation { get; set; }

	[field: FieldOffset(0x10)]
	public Array5<InstructionOperand> Operands { get; set; }

	[field: FieldOffset(0x240)]
	public FlagEffect SetFlags { get; set; }

	public override unsafe string ToString() {
		Span<byte> buf = stackalloc byte[0x400];
		var self = stackalloc Instruction[1];
		self[0] = this;
		fixed (byte* ptr = buf) {
			var sz = NativeMethods.aarch64_disassemble(self, ptr, (nuint) buf.Length);
			if (sz < 0) {
				return "error";
			}
		}

		var len = buf.IndexOf((byte) 0);
		if (len == -1) {
			len = buf.Length;
		}

		return Encoding.ASCII.GetString(buf[..len]);
	}
}
