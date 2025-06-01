// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Arm64Disassembler.Native.Arrays;

[InlineArray(10)]
public struct Str10 : IEquatable<Str10> {
	public byte Value;

	public override int GetHashCode() {
		var bytes = MemoryMarshal.AsBytes((ReadOnlySpan<byte>) this);
		var hc = new HashCode();
		hc.AddBytes(bytes);
		return hc.ToHashCode();
	}

	public override bool Equals(object? obj) => obj is Str10 array && Equals(this, array);
	public static bool operator ==(Str10 left, Str10 right) => left.Equals(right);
	public static bool operator !=(Str10 left, Str10 right) => !(left == right);
	public bool Equals(Str10 other) => ((ReadOnlySpan<byte>) this).SequenceEqual(other);

	public override string ToString() {
		var sb = new StringBuilder();
		for (var i = 0; i < 10; ++i) {
			if (this[i] == 0) {
				break;
			}

			sb.Append((char) this[i]);
		}

		return sb.ToString();
	}
}
