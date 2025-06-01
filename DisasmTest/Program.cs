// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Globalization;
using System.IO.MemoryMappedFiles;
using Arm64Disassembler;

namespace DisasmTest;

public static class Program {
	public static unsafe void Main(string[] args) {
		if (args.Length < 4) {
			Console.WriteLine("Usage: DisasmTest path/to/elf startOffset size RVA");
			return;
		}

		var path = args[0];
		var start = long.Parse(args[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		var size = int.Parse(args[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		var rva = nuint.Parse(args[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture);

		using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using var map = MemoryMappedFile.CreateFromFile(stream, null, stream.Length, MemoryMappedFileAccess.Read, HandleInheritability.None, false);
		using var accessor = map.CreateViewAccessor(start, size, MemoryMappedFileAccess.Read);
		var ptr = (byte*) nint.Zero;
		accessor.SafeMemoryMappedViewHandle.AcquirePointer(ref ptr);
		ptr += accessor.PointerOffset;
		var span = new Span<byte>(ptr, size);

		// this formatting is cursed.
		var instrs = new InstructionCollection { { span, rva } };
		// instrs.Add(span, rva);
		foreach (var instr in instrs) {
			Console.WriteLine(instr.ToString());
		}
	}
}
