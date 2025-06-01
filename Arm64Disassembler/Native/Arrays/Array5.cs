// SPDX-FileCopyrightText: 2025 chronovore/legiayayana
//
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Arm64Disassembler.Native.Arrays;

[InlineArray(5)]
public struct Array5<T> : IEquatable<Array5<T>> where T : struct {
	public T Value;

	public override int GetHashCode() {
		var bytes = MemoryMarshal.AsBytes((ReadOnlySpan<T>) this);
		var hc = new HashCode();
		hc.AddBytes(bytes);
		return hc.ToHashCode();
	}

	public override bool Equals(object? obj) => obj is Array5<T> array && Equals(this, array);
	public static bool operator ==(Array5<T> left, Array5<T> right) => left.Equals(right);
	public static bool operator !=(Array5<T> left, Array5<T> right) => !(left == right);
	public bool Equals(Array5<T> other) => ((ReadOnlySpan<T>) this).SequenceEqual(other);

	public override string ToString() => $"[ {this[0]}, {this[1]}, {this[2]}, {this[3]}, {this[4]} ]";
}
