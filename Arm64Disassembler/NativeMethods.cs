// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Reflection;
using System.Runtime.InteropServices;
using Arm64Disassembler.Native;

namespace Arm64Disassembler;

internal static partial class NativeMethods {
	static NativeMethods() {
		NativeLibrary.SetDllImportResolver(typeof(NativeMethods).Assembly, DllImportResolver);
	}

	internal static nint DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath) {
		if (NativeLibrary.TryLoad(libraryName, assembly, searchPath, out var handle)) {
			return handle;
		}

		if (searchPath != null && (searchPath & DllImportSearchPath.AssemblyDirectory) == 0) {
			return nint.Zero;
		}

		string ext;
		if (OperatingSystem.IsWindows()) {
			ext = ".dll";
		} else if (OperatingSystem.IsLinux()) {
			ext = ".so";
		} else if (OperatingSystem.IsMacOS()) {
			ext = ".dylib";
		} else {
			return nint.Zero;
		}

		var name = Path.GetFileNameWithoutExtension(libraryName);
		var cwd = AppDomain.CurrentDomain.BaseDirectory;

		foreach (var dir in new[] { Path.Combine(cwd, $"runtimes/{RuntimeInformation.RuntimeIdentifier}/native/"), cwd }) {
			foreach (var prefix in new[] { "lib", "" }) {
				var target = Path.Combine(dir, prefix + name) + ext;
				if (!File.Exists(target)) {
					continue;
				}

				var ptr = NativeLibrary.Load(target);
				if (ptr != nint.Zero) {
					return ptr;
				}
			}
		}

		return nint.Zero;
	}

	private const string LIB = "binjaarch64";

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	public static unsafe partial int aarch64_decompose(uint instructionValue, Instruction* instr, ulong address);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	public static unsafe partial int aarch64_disassemble(Instruction* instruction, byte* buf, nuint bufSize);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	public static unsafe partial uint get_implementation_specific(InstructionOperand* operand, byte* outBuffer, nuint outBufferSize);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	public static partial nuint get_register_size(Register register);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	public static unsafe partial int get_register_full(Register register, InstructionOperand* operand, byte* result);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static unsafe partial string get_register_arrspec(Register register, InstructionOperand* operand);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static unsafe partial string get_operation(Instruction* operand);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static partial string get_shift(ShiftType shift);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static partial string get_condition(Condition cond);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static partial string get_arrspec_str(ArrangementSpec arrSpec);

	[LibraryImport(LIB)] [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static partial string get_arrspec_str_truncated(ArrangementSpec arrSpec);
}
